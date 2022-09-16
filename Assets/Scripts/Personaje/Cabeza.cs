using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabeza : MonoBehaviour
{
    public int ContadorCabeza = 0;
    public Movimiento movimiento;
    public float DistanciaCabeza = 2.2f;

    public void FixedUpdate()
    {
        RaycastHit hit;
        if(movimiento.agachado && Physics.Raycast(transform.position, Vector3.up, out hit, DistanciaCabeza))
        {
            ContadorCabeza=1;
        }
        else
        {
            ContadorCabeza = 0;
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
