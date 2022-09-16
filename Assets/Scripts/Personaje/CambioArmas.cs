using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioArmas : MonoBehaviour
{
    public int espacio = 1;
    public bool reset;
    public GameObject EspacioArma1, EspacioArma2, EspacioArma3;
    public bool Scroll;
    public bool uso;
    public HookScript Atraer;
    public GrapplingGun Gancho;
    public Baston baston;
    public BastonLaser laser;
    public Vida vida;
    void Start()
    {
        reset = true;
        uso = true;
        Scroll = true;
    }
    void Update()
    {
        if (reset)
        {
            
            Atraer.uso = false;
            Gancho.uso = false;
            EspacioArma1.SetActive(false);

            baston.uso = false;
            laser.uso = false;
            EspacioArma2.SetActive(false);

            vida.uso = false;
            EspacioArma3.SetActive(false);

            
            reset = false;
        }
        if(uso)
        {
        if(Gancho.isGrappling || vida.usar)
        {
          Scroll = false;
        }
        else
        {
          Scroll = true;
        }

            
        if(Scroll)
        {
         if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            espacio++;

            reset = true;
        }

         if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            espacio--;

            reset = true;
        }

        

        switch (espacio)
        {
            case 0:
                espacio = 3;
                break;

            case 1:
                Atraer.uso = true;
                Gancho.uso = true;
                EspacioArma1.SetActive(true);

                break;

            case 2:
                baston.uso = true;
                laser.uso = true;
                EspacioArma2.SetActive(true);

                break;

            case 3: 
                vida.uso = true;
                EspacioArma3.SetActive(true);

                break;

            case 4:
                espacio = 1;
                break;
        }
        }
    }
    }
}