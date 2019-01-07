using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
   
    public void setName(string name)
    {
        GetComponent<TextMesh>().text = name;
        Debug.Log("" + GetComponent<TextMesh>().text);
    }

}
