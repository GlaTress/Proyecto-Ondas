using System.Collections;
using System.Collections.Generic;
using UnityEngine;                      //LIBRERÍAS
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class ContadorReto1 : MonoBehaviour
{
    public TMP_Text contador;
    public static int CantidadFichas;
    public GameObject UIFinalReto;          //SECCIÓN DE DECLARACIÓN DE VARIABLES, SIEMPRE POR FUERA DE LAS FUNCIONES!
    public VideoPlayer Video;
    // Start is called before the first frame update
    void Start()
    {
        
        contador.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        contador.text = CantidadFichas.ToString() + "/9"; //Colocar el número de fichas que se tiene en el contador
        if(CantidadFichas >= 9){ //Comprobar si ya se terminó el reto
            UIFinalReto.SetActive(true);
            Video.Prepare();
            CantidadFichas = 0; //Reiniciar la cantidad de fichas para que el condicional sea falso
            
        }
        //Debug.Log(Video.isPlaying);
        if(Video.isPlaying == false){ //Detectar cuando el video de finalizado el reto termine para esconderlo
            UIFinalReto.SetActive(false);
            
        }
    }
}
