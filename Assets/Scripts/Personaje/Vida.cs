using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vida : MonoBehaviour
{
    public Animator anim;
    public Slider visualVida;
    public SphereCollider Escudo;
    public MeshRenderer escudovisual;
    bool escudo = false;
    public bool AnimDaño;
    public bool escudoactive = false;
    public int vida = 100;
    public bool invencible = false;
    public float Tiempo = 1;
    public bool usar = true;
    public bool uso = true;
    public CambioArmas cambiar;

    public void Start()
    {
        Escudo.enabled = false;
        escudovisual.enabled = false;
    }
    public void Update()
    {
        visualVida.GetComponent<Slider>().value = vida;
        
       
        if(AnimDaño)
        {
            anim.SetBool("Daño", true);
            AnimDaño = false;
            
        }
        else
        {
            anim.SetBool("Daño", false);
        } 
      if(uso)
      {

        if(!usar)
        {
            escudoactive= false;
            escudovisual.enabled = false;
        }
        else
        {
           escudoactive= true;
        }
        if(usar)
        {
        if (Input.GetMouseButton(1))
        {
            Escudo.enabled = true;
            escudo = true;
            escudovisual.enabled = true;
            StartCoroutine(Time());
        }
        else
        {
            Escudo.enabled = false;
            escudo = false;
            escudovisual.enabled = false;

        }
        }
      }
        
    }

    public void Disminuir(int cantidad)
    {
        if (!invencible && vida > 0)
        {
            vida -= cantidad;
            StartCoroutine(Invencible());
        }  
    }

    IEnumerator Invencible()
    {
        invencible = true;
        AnimDaño = true;
        yield return new WaitForSeconds(Tiempo);
        
        
        invencible = false;
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(5f);
        usar = false;
        yield return new WaitForSeconds(5f);
        usar = true;
    }
    
    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy") && !escudo)
        {
            escudoactive = false;
        }
        else if(escudo)
        {
            escudoactive = true;
        }

        if (other.gameObject.CompareTag("Damage"))
        {
            Disminuir(10);
        }
    }
}
