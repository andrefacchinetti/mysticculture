using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

   
    public void changeLevelToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void changeLevelToMapa1x1()
    {
        SceneManager.LoadScene("Mapa1x1");
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
