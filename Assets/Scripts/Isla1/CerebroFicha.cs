using System.Collections;
using System.Collections.Generic;       //LIBRERÍAS
using UnityEngine;

public class CerebroFicha : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) { //Detectar cuando el jugador toca el objeto
        Destroy(gameObject);    //Desaparecer el objeto
        ContadorReto1.CantidadFichas += 1;  //Sumar 1 al contador de fichas
    }
}
