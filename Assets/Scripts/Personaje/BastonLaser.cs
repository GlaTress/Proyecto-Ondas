using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BastonLaser : MonoBehaviour
{
    public Transform grapplingHook; 
    public Transform grapplingHookEndPoint;
    public Transform handPos;
    public float maxGrappleDistance;
    public LayerMask GrappleLayer;
    public float hookSpeed;
    public float cont = 0;
    public bool tiempo = false;
    public bool uso = true;
    public bool Disparo;
    public bool disparoObjeto = false;

    public bool Activo = false;
    public LineRenderer lineRenderer;

    public bool isShooting, isGrappling;
    public Vector3 hookPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          

        if(Activo)
        {
            lineRenderer.enabled = true;
        }
        if(cont > 6)
        {
            StartCoroutine(Espera());
        }
        if(!Activo || cont > 6)
        {
            isGrappling = false;
                    lineRenderer.enabled = false;
        }

        if(uso)
        {
          
        if(Input.GetMouseButton(1) && !tiempo)
        {
            cont += 1 * Time.deltaTime;
            Activo = true;
        }

         if(Input.GetMouseButtonUp(1))
        {
            StartCoroutine(Espera());
                Activo = false;
        }
  
        }
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isHook = Physics.Raycast(handPos.transform.position, transform.TransformDirection(Vector3.forward), out hit, GrappleLayer);
        
        if (isHook && Activo)
        {
            Disparo = true;
            grapplingHook.position = hit.point;
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<VidaEnemigo>().Disminuir(1);
                
            } 
            if (hit.collider.gameObject.tag == "Drag")
            {
                hit.collider.gameObject.GetComponent<Comportamiento>().colisiono = true;
                
            } 
        }
        else
        {
            Disparo = false;
            
        }

        
    }

     private void LateUpdate()
    {
        lineRenderer.SetPosition(0, handPos.position);

        if(Disparo)
        {
            lineRenderer.SetPosition(1, grapplingHook.position);
        }
        else
        {
            lineRenderer.SetPosition(1, grapplingHookEndPoint.position);
        }
            
    }
        
    
    
    
        
    
    
    IEnumerator Espera()
    {
        tiempo = true;
        yield return new WaitForSeconds(6);
        tiempo = false;
        cont = 0f;
    }
}
