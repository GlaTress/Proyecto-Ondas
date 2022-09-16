using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teletransporte : MonoBehaviour
{
    public Transform Target;
    public Transform Jugador;
    public string SigienteNivel;
    

void OnTriggerEnter(Collider other) {    
        //Teletransportar de un punt A a un punto B
        //Jugador.transform.position = Target.transform.position;
        //Physics.SyncTransforms();

        //Cambiar de escena
        SceneManager.LoadScene(SigienteNivel);
    }
}
