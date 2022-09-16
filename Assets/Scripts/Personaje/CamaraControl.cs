using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    public float despTiempo =0f;
    public Movimiento movJug;
    public Interactuar interac;
    public bool activeTP, Activo;
    public GameObject persvisible;
    public Transform posTP, posPP, posPPAga;

    //Camara TP
    public float rotSpeed;
    public float rotMin, rotMax;
    public float mouseX, mouseY;
    public Transform target, player;
    public float minDistancia = 1;
    public float maxDistancia = 5;
    public float suavidad = 10;
    private float distancia;
    public LayerMask LayerCam;
    public float PosCam;
    public bool EsTP = true;

    Vector3 direccion;




    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        direccion = transform.localPosition.normalized;
        distancia = transform.localPosition.magnitude;
        
    }

    public void Cam()
    {
        if(Activo)
        {
        mouseX += rotSpeed * Input.GetAxis("Mouse X");
        mouseY -= rotSpeed * Input.GetAxis("Mouse Y");
        }
        mouseY = Mathf.Clamp(mouseY, rotMin, rotMax);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0.0f);
        player.rotation = Quaternion.Euler(0.0f, mouseX, 0.0f);
    }

    void LateUpdate()
    {
        Cam();
        if(movJug.agachado && activeTP)
        {
            transform.position = Vector3.Lerp(transform.position, posPPAga.position, despTiempo * Time.deltaTime );
        }
        
        else if(!movJug.agachado && activeTP)
        {
            transform.position = Vector3.Lerp(transform.position, posPP.position, despTiempo * Time.deltaTime );
        }
        if (activeTP == false && Input.GetKeyDown(KeyCode.Tab))
        {
            activeTP = true;
            transform.position = Vector3.Lerp(transform.position, posPP.position, despTiempo * 2 * Time.deltaTime );
            persvisible.SetActive(false);
            suavidad = 0;
            interac.distancia = 14f;
            
        }
        else if(activeTP == true && Input.GetKeyDown(KeyCode.Tab))
        {
            activeTP = false;
            transform.position = Vector3.Lerp(transform.position, posTP.position, despTiempo * Time.deltaTime );
            transform.LookAt(player);
            suavidad = 10;
            persvisible.SetActive(true);
            EsTP= true;
            
            interac.distancia = 28f;

        }

       
    }
    void Update()
    {
        Vector3 posDeCamara = transform.parent.TransformPoint(direccion * maxDistancia);
        if(EsTP)
        {
            transform.rotation = posTP.rotation;
        }
        RaycastHit hit;
        if (Physics.Linecast(transform.parent.position, posDeCamara, out hit, LayerCam))
        {
            distancia = Mathf.Clamp(hit.distance * 0.65f, minDistancia, maxDistancia);
        }
        else
        {
            distancia = maxDistancia;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, direccion * distancia, suavidad * Time.deltaTime);
    }
}
