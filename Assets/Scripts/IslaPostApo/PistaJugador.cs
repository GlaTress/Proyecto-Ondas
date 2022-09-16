using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistaJugador : MonoBehaviour
{
    public int ValorCheckPoints, ValorCheckMax,PistaJug;
    public Transform[] CheckPoints;
    public Transform Objetivo;
    void Start()
    {
        
    }
    void Update()
    {
      Objetivo.position = CheckPoints[ValorCheckPoints].position;
      if(Vector3.Distance(transform.position, Objetivo.position) < 20f)
      {
        ValorCheckPoints++;
      }
      if(ValorCheckPoints >= ValorCheckMax)
      {
        PistaJug++;
        ValorCheckPoints = 0;
      }
    }
}
