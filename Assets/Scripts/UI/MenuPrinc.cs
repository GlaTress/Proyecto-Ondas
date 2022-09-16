using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Manejo de escenas

public class MenuPrinc : MonoBehaviour
{

    public void Jugar(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Cargar la siguiente escena en build settings

    }

    public void Salir(){
        Debug.Log("Saliendo!");
        Application.Quit(); //Salir del juego
    }

}
