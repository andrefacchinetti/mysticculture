using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class NetworkSocketIO : MonoBehaviour
{
    private SocketIOComponent socket;
    InputField mainInputField;

    GameObject canvas;
    bool onLogin;
    public GameObject playerPrefab;
    public GameObject networkPlayerPrefab; //prefab dos outros players
    protected GameObject myPlayer;


    public void Start()
    {
        this.mainInputField = FindObjectOfType(typeof(InputField)) as InputField; //pega o objeto input onde digita o nome futuramente devera ser o nome do player baseado no login
        canvas = GameObject.Find("HDUCanvas");
        this.onLogin = false;

        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();

        socket.On("open", TestOpen);
        socket.On("boop", TestBoop);
        socket.On("LOGIN_SUCESS", OnLoginSucess);
        socket.On("SPAWN_PLAYER", OnInstantiateNetworkPlayer);
        socket.On("UPDATE_MOVE", OnUserMove);
        socket.On("UPDATE_ROTATE", OnUserRotate);
        socket.On("USER_DISCONNECTED", OnUserDisconnected);
        socket.On("error", TestError);
        socket.On("close", TestClose);

        StartCoroutine("BeepBoop");
    }

    public void Update()
    {

    }

    private IEnumerator BeepBoop()
    {
        // wait 1 seconds and continue
        yield return new WaitForSeconds(1);

        socket.Emit("beep");

    }

    public void TestOpen(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
    }

    public void TestBoop(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Boop received: " + e.name + " " + e.data);

        if (e.data == null) { return; }

        Debug.Log(
            "#####################################################" +
            "THIS: " + e.data.GetField("this").str +
            "#####################################################"
        );
    }

    public void TestError(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
    }

    public void TestClose(SocketIOEvent e)
    {
        Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
    }

    public void OnClickPlayBtn()
    {
        if (this.mainInputField.text != "")
        {
            //add verificacao para fazer essas coisas somente se o login for validado com conexao
            this.canvas.SetActive(false);
            this.onLogin = true;
            Dictionary<string, string> data = new Dictionary<string, string>(); //pacote JSON
            data.Add("name", this.mainInputField.text); //data["name"] = mainInputField.text;
            Vector3 position = new Vector3(0, 3f, 0);
            Vector3 rotation = new Vector3(0, 0, 0);
            data.Add("position", position.x + "," + position.y + "," + position.z);
            data.Add("rotation", rotation.x + "," + rotation.y + "," + rotation.z);

            socket.Emit("LOGIN", new JSONObject(data));
        }
        else
        {
            this.mainInputField.text = "Digite seu nickname";
        }
    }

    void OnLoginSucess(SocketIOEvent _myPlayer)
    {
        Debug.Log("LOGIN SUCESS");

        myPlayer = GameObject.Instantiate(playerPrefab, JsonToVector3(JsonToString(_myPlayer.data.GetField("position").ToString(), "\"")), Quaternion.identity) as GameObject; //instanciar player
        this.onLogin = true;
        Debug.Log("JSONTOVECTOR3: " + _myPlayer.data.GetField("position").ToString());
    }

    void OnInstantiateNetworkPlayer(SocketIOEvent _newPlayer)
    {
        if (this.onLogin)
        {
            GameObject newPlayer = GameObject.Instantiate(networkPlayerPrefab, JsonToVector3(JsonToString(_newPlayer.data.GetField("position").ToString(), "\"")), Quaternion.identity) as GameObject; //instanciar player
            newPlayer.name = JsonToString(_newPlayer.data.GetField("name").ToString(), "\"");
        }
    }

    void OnUserDisconnected(SocketIOEvent _user)
    {
        Destroy(GameObject.Find(JsonToString(_user.data.GetField("name").ToString(), "\""))); //acha o player para destruir pelo name
    }

    void OnUserMove(SocketIOEvent _user)
    {
        GameObject networkPlayer = GameObject.Find(JsonToString(_user.data.GetField("name").ToString(), "\"")) as GameObject; //encontra o player pelo name
        NetworkPlayerController playerCom = networkPlayer.GetComponent<NetworkPlayerController>() as NetworkPlayerController; //guarda o  networkplayercontroller
        playerCom.Move(JsonToVector3(JsonToString(_user.data.GetField("position").ToString(), "\""))); //chama o metodo para mudar o move transform dele
        //networkPlayer.transform.position = JsonToVector3(JsonToString(_user.data.GetField("position").ToString(), "\"")); //tambem muda o transform mode, mas a forma de cima fica amis organizado
    }

    void OnUserRotate(SocketIOEvent _user)
    {
        GameObject networkPlayer = GameObject.Find(JsonToString(_user.data.GetField("name").ToString(), "\"")) as GameObject; //encontra o player pelo name
        Vector4 rot = JsonToVector4(JsonToString(_user.data.GetField("rotation").ToString(), "\""));
        NetworkPlayerController playerCom = networkPlayer.GetComponent<NetworkPlayerController>() as NetworkPlayerController; //guarda o  networkplayercontroller
        playerCom.Rotate(new Quaternion(rot.x, rot.y, rot.z, rot.w));

    }


    string JsonToString(string target, string s)
    {
        string[] newString = Regex.Split(target, s);
        return newString[1];
    }

    //metodo responsavel por transmitir ao servidor o movimento do player associado
    public void EmitPosition(Vector3 _pos)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        Vector3 position = new Vector3(_pos.x, _pos.y, _pos.z);
        data.Add("position", position.x + "," + position.y + "," + position.z);
        socket.Emit("MOVE", new JSONObject(data));
    }

    //metodo responsavel por transmitir ao servidor a rotaçao do player associado
    public void EmitRotation(Quaternion _rot)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("rotation", _rot.x + "," + _rot.y + "," + _rot.z + "," + _rot.w);
        socket.Emit("ROTATE", new JSONObject(data));
    }

    Vector3 JsonToVector3(string target) //string para vector3
    {
        Vector3 newVector;
        string[] newString = Regex.Split(target, ",");
        newVector = new Vector3(float.Parse(newString[0]), float.Parse(newString[1]), float.Parse(newString[2]));
        return newVector;
    }

    Vector4 JsonToVector4(string target) //string para vector3
    {
        Vector4 newVector;
        string[] newString = Regex.Split(target, ",");
        newVector = new Vector4(float.Parse(newString[0]), float.Parse(newString[1]), float.Parse(newString[2]), float.Parse(newString[3]));
        return newVector;
    }


}
