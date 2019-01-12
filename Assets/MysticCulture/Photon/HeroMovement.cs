using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroMovement : MonoBehaviour
{
    //ESSE SCRIPT SERVE PARA MOVIMENTAÇÃO IGUAL DO LOL ONDE VC CLICKA PARA ANDAR E ELE VAI PRO DESTINO FINAL DESVIANDO DOS OBSTACULOS
    private NavMeshAgent agent;
    private Vector3 targetDestination;
    private PhotonView photon;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        photon = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && photon.isMine) //ismine pergunta se eh o meu photon
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit)) //pode usar distancia como terceiro parametro
            {
                targetDestination = hit.point;
                agent.SetDestination (targetDestination);
            }
        }
    }
}
