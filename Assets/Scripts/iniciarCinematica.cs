using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class iniciarCinematica : MonoBehaviour
{
    public Movimiento MovJugador;
    public PlayableDirector director;
    public bool inicio, DetenerMovimiento;
    void Update()
    {
        
        if(inicio)
        {
            director.Play();
            inicio = false;
            if(DetenerMovimiento)
            {
                MovJugador.Mueve = false;
            MovJugador.MueveY = false;
            }
            
        }
        director.stopped += OnPlayableDirectorPaused;
        
    }

    void OnPlayableDirectorPaused( PlayableDirector aDirector)
    {
        if(DetenerMovimiento)
        {
            MovJugador.Mueve = true;
            MovJugador.MueveY = true;
        }
    }
}
