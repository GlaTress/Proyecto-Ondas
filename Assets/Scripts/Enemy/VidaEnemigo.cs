using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public Baston baston;
    public GameObject Daño;
    public string DañoEnemigo;
    public float daño;

    public float vida = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        daño = baston.Tamaño;
        if(vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Disminuir(float cantidad)
    {
        if ( vida > 0)
        {
            vida -= cantidad;
        }  
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(DañoEnemigo))
        {
            Disminuir(daño);
        }
    }
}
