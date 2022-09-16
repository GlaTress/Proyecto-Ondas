using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int cantidad = 10;
    public int cantidadBloqueo = 0;
    public int cantidadFinal;
    public Vida vida;
    public HookObject Hook;
    public GameObject enemy;
    public GameObject Jugador;

    public void Start()
    {
    }



    public void Update()
    {
        if(Hook.Activo)
        {
            gameObject.GetComponent<Enemigo>(). enabled = false;
        }

        if(Hook.grapple == false)
        {
            gameObject.GetComponent<Enemigo>(). enabled = true;
        }
        if (vida.escudoactive)
        {
            cantidadFinal = cantidadBloqueo;
        }
        else
        {
            cantidadFinal = cantidad;
            

        }
        if (Hook.Onplayer && Hook.hook.isGrapp)
        {
            Hook.hook.isGrapp = false;
        }

          if(Vector3.Distance(transform.position, Jugador.transform.position) < 8f)
                    {
                        Jugador.GetComponent<Vida>().Disminuir(cantidadFinal);
                    }

    }    

}
