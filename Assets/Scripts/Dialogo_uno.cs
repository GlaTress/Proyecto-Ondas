using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo_uno : MonoBehaviour
{
    public GameObject UICHAT; 
    public GameObject UICONV1; 
    public TMP_Text display;    //SECCIÓN DE DECLARACIÓN DE VARIABLES
    public int control = 0; 
    private bool InRange; 
    public bool DialogoTerminado = false; 
    private int index = 0;


    
    public string[] chat = new string[]{ "Hola hijo mío, me alegra verte por acá", //STRINGS DEL DIALOGO
     "Sí, eres Jefferson Steven", 
     " Oh, ¿cómo me conoces?", 
     "Tu historia es conocida por las personas que habitan este lugar, al parecer eres más conocido de lo que crees.",
     "Veo que tienes problemas Jefferson Steven, ¿qué tal si me acompañas en una pequeña travesía?.",
     " Hola hijo mío, me alegra verte por acá", //LÍNEA PROVISIONAL
     }; 
    
    void Start()
    {
        display.text = "Hola hijo mío, me alegra verte por acá";
        UICHAT.SetActive(false);
        //Debug.Log(chat[0]);
        
    }

    // Update is called once per frame

    void Update()
    {
        if(InRange){
            if(Input.GetKeyDown(KeyCode.E)){
            UICHAT.SetActive(false);
            UICONV1.SetActive(true);            //OBJETIVO: PASAR 1 POR 1 CADA LÍNEA DE DIALOGO, SE HA INTENTADO CON FOREACH
                while(true){
                    if(Input.GetKeyDown(KeyCode.E)){
                        index++;
                        display.text = chat[index];     //TODA ESTA SECCIÓN ESTÁ EN DESARROLLO
                        Debug.Log(index);               //DEBEMOS ENCONTRAR LA MANERA DE PASAR UNO POR UNO CADA ELEMENTO DEL ARRAY CHAT[]
                        if(index >= chat.Length){
                            break; //PARA QUE NO EXPLOTE EL COMPUTADOR CON EL BUCLE INFINITO while(true)
                        }
                        else{
                            continue;
                        }
                    }
                    else if(Input.GetKeyDown(KeyCode.Return)){
                        InRange = false;
                        break;
                    }
                    else{
                        continue;
                    }
                }
            }
        }
    }
    /*private void Cerebro(){
        int index = 0;
        do{
            display.text = chat[index];
            index++;
        }
        while(!Input.GetKeyDown(KeyCode.E));
    }
    */
    private void OnTriggerStay(Collider other) {
        InRange = true;
        UICHAT.SetActive(true);
        
    }
    private void OnTriggerExit(Collider other) {
        InRange = false;
        UICHAT.SetActive(false);
        UICONV1.SetActive(false);
    }
}
