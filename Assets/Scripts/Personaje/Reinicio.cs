using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reinicio : MonoBehaviour
{
    
    public int IndiceNivel;
    public Vida vida;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( vida.vida <= 0)
        {
            SceneManager.LoadScene(IndiceNivel);
        }
    }
}
