using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookObject : MonoBehaviour
{
    public HookScript hook;
    public bool grapple = false;
    public bool Onplayer = false;
    public bool Activo = false;
    public GameObject jugador;
    public GameObject Hook;

    void Update()
    {
        Activo = false;

         if(Vector3.Distance(transform.position, jugador.transform.position) < 9f)
                    {
                        grapple = false;
                        hook.isGrapp = false;
            hook.isGrappling = false;
            hook.grapplingHook.SetParent(hook.handPos);
            hook.lineRenderer.enabled = false;
            
                    }

        if(Vector3.Distance(transform.position, Hook.transform.position) < 2f)
                    {
                        grapple = true;
                    }

        if (grapple)//Vector3.Distance(playerBody.position, hookPoint - offset) < 0.5f)
        {
            // hook.controlador.enabled = false;
            StartCoroutine("Tiempo");
            
            
           
        }


        else
        {
            StopCoroutine("Tiempo");
        }

       
    }
        IEnumerator Tiempo()
    {
        //nuevo bool
        // verdadero para que no afecte la moneda llamando desde enemy
         Activo = true; 
         yield return new WaitForSecondsRealtime(1f);
         Activo = false;
            hook.Hook.SetActive(false);
        transform.position = Vector3.Lerp(transform.position, hook.playerBody.position - hook.offset, hook.hookSpeed * Time.deltaTime);//falso
    }
}