using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teletransportar : MonoBehaviour
{
    public bool pasarNivel;
    public int IndiceNivel;
    public bool Entro;
    public float aumenta;

    void Update()
    {
        if(aumenta >= 2)
        {
            //efecto de distorsion
            Entro = true;
            
        }
        if(Entro)
        {
            CambiarNivel(IndiceNivel);
        }
        if(pasarNivel)
        {
            CambiarNivel(IndiceNivel);
        }
    }

    public void CambiarNivel(int Indice)
    {
        SceneManager.LoadScene(Indice);
    }

    void OnTriggerStay(Collider colisor)
    {
        if(colisor.gameObject.CompareTag("Player"))
        {
            aumenta += 1f * Time.deltaTime;
        }
    }
    void OnTriggerExit(Collider colisor)
    {
        if(colisor.gameObject.CompareTag("Player"))
        {
            aumenta += 0f;
        }
    }
}
