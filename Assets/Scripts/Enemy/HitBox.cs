using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
   public Vida vida;
    public GameObject Jugador;
    public int cantidad = 10;
    public int cantidadBloqueo = 0;
    public int cantidadFinal;
    
    void Start()
    {
        
    }

    
    void Update()
    {
      if (vida.escudoactive)
        {
            cantidadFinal = cantidadBloqueo;
        }
        else
        {
            cantidadFinal = cantidad;
            

        }

       if(Vector3.Distance(transform.position, Jugador.transform.position) < 5f)
                    {
                        Jugador.GetComponent<Vida>().Disminuir(cantidadFinal);
                    }
                  
    }
}
