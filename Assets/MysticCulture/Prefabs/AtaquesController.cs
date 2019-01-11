using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AtaquesController : MonoBehaviour
{
    //Boleano global para verificar se o usuario esta efetuando algum ataque, ELA EH UTILIZADA NOS SCRIPTS DE FETIÇOS E GOLPES
    public static bool isAtaqueA;
    public float countdownA = 2.0f; float contadorA;
    public static bool isAtaqueB;
    public float countdownB = 2.0f; float contadorB;
    public static bool isAtaqueX;
    public float countdownX = 4.0f; float contadorX;
    public static bool isAtaqueY;
    public float countdownY = 4.0f; float contadorY;

    public Button buttonAtaqueA;
    public Button buttonAtaqueB;
    public Button buttonAtaqueX;
    public Button buttonAtaqueY;

    bool countA;
    bool countB;
    bool countX;
    bool countY;
    // Start is called before the first frame update
    void Start()
    {
        contadorA = countdownA;
        contadorB = countdownB;
        contadorX = countdownX;
        contadorY = countdownY;
    }

    // Update is called once per frame
    void Update()
    {
        if (countA)
        {
            contadorA -= Time.deltaTime;
            if (contadorA <= 0.0f)
            {
                contadorA = countdownA;
                buttonAtaqueA.interactable = true; //deixa botao clicavel apos o contdown 
                countA = false;
            }            
        }
        if (countB)
        {
            contadorB -= Time.deltaTime;
            if (contadorB <= 0.0f)
            {
                contadorB = countdownB;
                buttonAtaqueB.interactable = true; //deixa botao clicavel apos o contdown 
                countB = false;
            }
        }
        if (countX)
        {
            contadorX -= Time.deltaTime;
            if (contadorX <= 0.0f)
            {
                contadorX = countdownX;
                buttonAtaqueX.interactable = true; //deixa botao clicavel apos o contdown 
                countX = false;
            }
        }
        if (countY)
        {
            contadorY -= Time.deltaTime;
            if (contadorY <= 0.0f)
            {
                contadorY = countdownY;
                buttonAtaqueY.interactable = true; //deixa botao clicavel apos o contdown 
                countY = false;
            }
        }

    }

    public void ativarAtaqueA()
    {
        isAtaqueA = true; //variavel global, usada para ativar no controller dos golpes
        countA = true;
        buttonAtaqueA.interactable = false; //deixa o bottao nao clicavel
    }
    public void ativarAtaqueB()
    {
        isAtaqueB = true; //variavel global, usada para ativar no controller dos golpes
        countB = true;
        buttonAtaqueB.interactable = false; //deixa o bottao nao clicavel
    }
    public void ativarAtaqueX()
    {
        isAtaqueX = true; //variavel global, usada para ativar no controller dos golpes
        countX = true;
        buttonAtaqueX.interactable = false; //deixa o bottao nao clicavel
    }
    public void ativarAtaqueY()
    {
        isAtaqueY = true; //variavel global, usada para ativar no controller dos golpes
        countY = true;
        buttonAtaqueY.interactable = false; //deixa o bottao nao clicavel
    }



}
