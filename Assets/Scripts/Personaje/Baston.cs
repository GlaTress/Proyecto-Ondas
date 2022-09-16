using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Baston : MonoBehaviour
{
    

    public bool tiempo = false;
    public bool uso = true;
    public bool Disparo;

    public float Tamaño = 0.0f;

    
    public bool isShooting, isGrappling;
    public Vector3 hookPoint;

    public GameObject BalaInicio;
    public GameObject BalaPrefab, balaRecarga;
    public float BalaVelocidad;

    private void Start()
    {

    }

    private void Update()
    {
        if(uso)
        {
        if (Input.GetMouseButton(0) && Tamaño <= 25 &&  !tiempo)
        {
            Tamaño += 4 * Time.deltaTime;
            balaRecarga.SetActive(true);
            Disparo = false;

            
            
        }
        if(Input.GetMouseButtonUp(0) && Tamaño <= 25 &&  !tiempo)
            {
                Shoot();
                
            balaRecarga.SetActive(false);
                StartCoroutine(Espera());
                
                
            }

        if(Tamaño >= 25 && !tiempo)
        {
            
            balaRecarga.SetActive(false);
            Shoot();
            StartCoroutine(Espera());
        }

            if(Disparo)
            {
                Tamaño = 0;
            }

       
                    
        }
    }

    

    public void Shoot()
    {    
        GameObject BalaTemporal = Instantiate(BalaPrefab, BalaInicio.transform.position, BalaInicio.transform.rotation) as GameObject;

        BalaTemporal.transform.localScale = new Vector3( Tamaño, Tamaño, Tamaño);

        Rigidbody rb = BalaTemporal.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * BalaVelocidad);
        

        Destroy(BalaTemporal, Tamaño);
    }
    

    IEnumerator Espera()
    {
        tiempo = true;
        yield return new WaitForSeconds(Tamaño + 1);
        tiempo = false;
        Tamaño = 0;
        Disparo = true;
    }
}
