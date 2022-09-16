using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerebroMoneda : MonoBehaviour
{
    public float velocidad = 180;
    public Transform Cont;
    public GameObject Jugador;

    private void Update()
    {
        Cont.Rotate(Vector3.up * velocidad * Time.deltaTime);
        if(Vector3.Distance(transform.position, Jugador.transform.position) < 7f)
         {
            Dinero.CantidadDinero += 1;
            Destroy(gameObject);
        }
    }
    
       
}
