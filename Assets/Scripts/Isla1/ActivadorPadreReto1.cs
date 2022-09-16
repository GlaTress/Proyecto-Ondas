using System.Collections;
using System.Collections.Generic;      //LIBRERÍAS
using UnityEngine;
using UnityEngine.Video;

public class ActivadorPadreReto1 : MonoBehaviour //CLASE QUE EJECUTA EL ARCHIVO COMPLETO
{
    public GameObject UICHAT;
    public GameObject PuertaCerrada;
    public GameObject PuertaAbierta;
    public GameObject ConjuntosFichas;      //SECCIÓN DE DELARACIÓN DE VARIABLES
    public GameObject UIRETO1;
    public GameObject CanvasVideoIntro;
    public VideoPlayer Video;
    private bool InRange = false; //NOTA: Si Input.GetKeyDown() toca darle 1000000 veces para que funcione, es porque no debe estar
    //Dentro de OnTriggerStay, debe estar en Update, para eso se creó esta variable InRange
    
    
    //LA FUNCIÓN START() SE EJECUTA CADA PRIMER FRAME (CADA VEZ QUE UNO LE DA PLAY AL JUEGO), O SEA SOLO UNA VEZ 
    void Start()
    {

        Video.Prepare();
        ConjuntosFichas.SetActive(false);
        UIRETO1.SetActive(false);
    }

    //LA FUNCIÓN UPDATE() SE EJECUTA CADA FRAME, ES DECIR MUCHAS VECES DURANTE EL JUEGO, SIEMPRE QUE EL JUEGO ESTÉ EJECUTÁNDOSE
    void Update()
    {
        if(InRange){ //Para controlar cuando se ejecuta la función OnTriggerStay() y así que funcione la recepción del input del teclado
            if(Input.GetKeyDown("e")){
            ConjuntosFichas.SetActive(true);
            UIRETO1.SetActive(true);
            CanvasVideoIntro.SetActive(true);
            Video.Prepare();
            }
            if(Input.GetKeyDown(KeyCode.Return)){
            CanvasVideoIntro.SetActive(false);
            Video.Stop();   //No sirve :/
            }
            if(Video.isPlaying == false)   {
                CanvasVideoIntro.SetActive(false);
            }
            
        }
    }

    private void OnTriggerStay(Collider other) {
        InRange = true;
        UICHAT.SetActive(true);
        /*
        if(Input.GetKeyDown("e")){
            ConjuntosFichas.SetActive(true);
            UIRETO1.SetActive(true);
            CanvasVideoIntro.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Return)){
                CanvasVideoIntro.SetActive(false);      //SI PONEMOS ESTO ACÁ, NO FUNCIONA BIEN, POR ESO SE MOVIÓ A LA FUNCIÓN UPDATE
                Video.Stop();   //No sirve :/
            }
            if(Video.isPlaying == false)   {
                CanvasVideoIntro.SetActive(false);
            }
        }
        */

    }
    private void OnTriggerExit(Collider other) { //Función que detecta la salida del trigger
        InRange = false;
        UICHAT.SetActive(false);
        Destroy(PuertaCerrada);
        PuertaAbierta.SetActive(true);
        CanvasVideoIntro.SetActive(false);
    }
}



