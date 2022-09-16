using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar : MonoBehaviour
{
    public LayerMask Interac;
    public float distancia = 28f;
    public GameObject CanvasInterac;
    public GameObject ultimoReconocido = null;
    void Start()
    {
        CanvasInterac.SetActive(false);
        
    }

    
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, Interac))
        {
            if(hit.collider.transform.GetComponent<ObjetoInteractivo>(). interactuo ==  true)
            {
                CanvasInterac.SetActive(false);
            }

            if(hit.collider.transform.GetComponent<ObjetoInteractivo>(). interactuo ==  false)
            {
               
             if(hit.collider.tag == "Interactuar" )
            {
               
                 Deselect();
                 CanvasInterac.SetActive(true);
                 SelectObject(hit.transform);
                 
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<ObjetoInteractivo>(). ActivarObjeto();
                }
            }
            }
        }
        else
        {
            Deselect();
        }
    }

    void SelectObject(Transform transform)
    {
        transform.GetComponent<Outline>().enabled = true;
        ultimoReconocido = transform.gameObject;
    }
    void Deselect()
    {
        if(ultimoReconocido)
        {
            ultimoReconocido.GetComponent<Outline>().enabled = false;
            ultimoReconocido = null;
            CanvasInterac.SetActive(false);
            
        }
    }
    
}
