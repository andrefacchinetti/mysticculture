using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

    public Text txStatus;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        ConnectToPhoton();
    }

    // Update is called once per frame
    void Update()
    {
        //Input para criar sala
        if (Input.GetKeyDown(KeyCode.C))
        {
            PhotonNetwork.CreateRoom("nome_da_sala");
            txStatus.text = "Criou a sala";
            txStatus.color = Color.yellow;
        }
        //Input para entrar sala
        if (Input.GetKeyDown(KeyCode.E))
        {
            PhotonNetwork.JoinRoom("nome_da_sala");
        }
        //Input para instanciar os players
        if (Input.GetKeyDown(KeyCode.I))
        {
            PhotonNetwork.Instantiate("Kambai",new Vector3(-4.5f,3,-33),Quaternion.identity,0); //prefab tem q estar obrigatoriamente dentro da pasta "Resources" 
            camera.SetActive(false);
            txStatus.text = "Instanciou o player";
            txStatus.color = Color.green;
        }
    }

    void OnJoinedRoom()
    {
        txStatus.text = "Entrou na sala";
        txStatus.color = Color.magenta;
    }

    void OnJoinedLobby()
    {
        txStatus.text = "Em lobby";
        txStatus.color = Color.blue;
    }

    void ConnectToPhoton()
    {
        try
        {
            PhotonNetwork.ConnectUsingSettings("v1.0"); //v1.0 controle de versao para os clientes se conectarem somente quem tiver a mesma versao e nao bugar se um cliente tiver 1 personagem novo e o outro nao
            this.txStatus.text = "Conectado";
            this.txStatus.color = Color.green;
        }
        catch(UnityException error)
        {
            Debug.Log(error);
        }
    }
}
