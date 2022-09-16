using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public Transform jugador;
    public float vel;
    public bool Activo;
    public bool sigue;
    Vector3 velocidad;

    public NavMeshAgent agent;
    public float distancia_ataque;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Activo)
        {

            if(sigue)
            {
                transform.LookAt(new Vector3(jugador.position.x, transform.position.y, jugador.position.z));
               //transform.position = Vector3.MoveTowards(transform.position, new Vector3(jugador.position.x, transform.position.y, jugador.position.z), vel * Time.deltaTime);
                agent.enabled = true;
                agent.SetDestination(jugador.transform.position);
            }
            else
            {
                agent.enabled = false;
            }

        
            if(Vector3.Distance(transform.position, jugador.transform.position) < 100f)
             {
               sigue = true;
             }  
             
             if(Vector3.Distance(transform.position, jugador.transform.position) > 600f)
             {
                sigue = false;
             }

        }
    }
}
