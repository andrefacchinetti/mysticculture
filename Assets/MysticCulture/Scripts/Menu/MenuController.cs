using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{


    public string MainMenu;
    public string Mapa1x1;
   
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Mapa1x1Scene()
    {
        SceneManager.LoadScene(Mapa1x1);
    }

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}
