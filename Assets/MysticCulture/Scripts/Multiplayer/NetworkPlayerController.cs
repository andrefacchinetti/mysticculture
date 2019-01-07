using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerController : MonoBehaviour
{

    PlayerName playerName;
    public string id;

    // Start is called before the first frame update
    void Start()
    {
        this.playerName = GetComponentInChildren<PlayerName>() as PlayerName;
        this.playerName.setName(this.name);
    }

    public void Move(Vector3 position)
    {
        transform.position = position;
    }

    public void Rotate(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

}
