using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    public bool interactuo;
    public void Update()
    {
        if(interactuo)
        {
        GetComponent<Outline>().enabled = false;
        }
    }
   
    public void ActivarObjeto()
    {
        interactuo = true;
    }
    
}
