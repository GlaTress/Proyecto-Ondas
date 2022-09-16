using System.Collections;
using System.Collections.Generic;       //LIBRERÍAS
using UnityEngine;
using UnityEngine.SceneManagement;
public class AdminMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Jugar()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //CARGAR SIGUIENTE NIVEL AL DARLE CLICK A JUGAR
    }

    // Update is called once per frame
    public void Salir() //SALIR DEL JUEGO AL PRESIONAR EL BOTÓN SALIR
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }
}
