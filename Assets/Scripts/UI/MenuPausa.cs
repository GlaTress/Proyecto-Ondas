using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//LAS FUNCIONES DE ABAJO FUERON ASIGNADAS A CADA BOTÓN DEL MENÚ DE PAUSA

public class MenuPausa : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject UIpausa;
    public GameObject jugador;
    
    // public AudioSource audio_manager; 

    void Start(){
    // audio_manager = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(JuegoPausado){
                Resumir();
            }
            else{
                Pausar();
            }
        }
    }

    public void Resumir(){
        UIpausa.SetActive(false);
        Time.timeScale = 1f;
        JuegoPausado = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        jugador.gameObject.transform.Find("Target").Find("Camera").GetComponent<CamaraControl>().enabled = true;

        //audio_manager.Play();
    }
    void Pausar(){
        UIpausa.SetActive(true);
        if( Time.timeScale >= 0.1f)
        {
        Time.timeScale = 0f;
        }
        JuegoPausado = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        jugador.gameObject.transform.Find("Target").Find("Camera").GetComponent<CamaraControl>().enabled = false;
        //  audio_manager.Stop();

    }

   

    public void CargarMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void CerrarJuego(){
        Debug.Log("Cerrando juego...");
        Application.Quit();

    }
}
