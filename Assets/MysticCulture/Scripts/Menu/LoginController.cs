using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    bool isConectadoFacebook;
    public GameObject botaoLogin;
    public GameObject inputUsername;
    public GameObject botaoConfirmar;
    MenuController menuControle = new MenuController();

    // Start is called before the first frame update
    void Start()
    {
        this.isConectadoFacebook = false;
        this.botaoLogin.SetActive(true);
        this.botaoConfirmar.SetActive(false);
        this.inputUsername.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (this.isConectadoFacebook)
       {
           this.botaoLogin.SetActive(false);
       }
    }

   public void conectarComFacebook()
    {
        //fazer a conexao com fazebook
        this.isConectadoFacebook = true;
        if (this.isPossuiCadastro()) this.menuControle.changeLevelToMainMenu();
        else this.inputUsername.SetActive(true);
        this.botaoConfirmar.SetActive(true);
    }

    bool isPossuiCadastro()
    {
        //if(currentUser.id existe no banco) return true;
        return false;
    }

    public void btnConfirmar()
    {
        if (this.inputUsername.GetComponent<InputField>().text != "" || this.verificarDisponibilidadeUsername())
        {
            //salvar username do usuario no banco
            this.menuControle.changeLevelToMainMenu();
        }
        else
        {
            Debug.Log("Apelido invalido");
        }
    }

    bool verificarDisponibilidadeUsername()
    {
        //if(buscarUsernameNoBanco(this.inputUsername.text)==true) return false; //username indisponivel
        return true;
    }

}
