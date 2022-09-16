using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Transform Cont;
    public float velocidad = 180;
    public float costo;

    private void Update()
    {
        Cont.Rotate(Vector3.up * velocidad * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (Dinero.CantidadDinero >= costo)
        {
            Destroy(gameObject);
        }
    }
}
