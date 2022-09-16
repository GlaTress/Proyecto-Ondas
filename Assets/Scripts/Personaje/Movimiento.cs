using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movimiento : MonoBehaviour
{
    [ColorUsage(true, true)]
    public Color Cerca,Medio,Lejos;
    public ParticleSystem Partic;
    public float AlertaCercana, AlertaLejana;
    public bool Alerta, Nube, CambiarPos, CambioPos;
    public GameObject ObjAlerta, alerta;
    public float AumentoComCo;
    public float AumentoComCa;
    public bool EnCombate;
    public bool Hablo;
    public bool Hablar, animHablar;
    public float detecSCont = 0f;
    public GameObject detecSalto;
    public CamaraControl Camara;
    public float cameraZoomIn = 50.0f;
    public float cameraZoomOut = 70.0f;
    public float TimeCamera = 70.0f;
    public Image imagenBarra;
    public CharacterController controlador;
    public Cabeza ScriptCabeza;
    public float acel_caminar = 20f;
    public float acel_final;
    public float acel_correr = 35f;
    public float acel_agachado;
    public float gravedad = -180f;
    public float jumpForce = 8f;
    public bool Salto;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Slider visualMana;
    public float mana = 250;
    public int costoMana = 1;
    public bool isGround;
    public Animator anim;
    public bool isgrounded;
    public int jumpCount = 2;
    public int jumpAct = 0;
    public int DashCount = 3;
    public int DashAct = 0;
    public bool PuedeDash = true;
    public float dashSpeed;
    public float dashTime;
    public bool gastoCorrer = true;
    public Slider slider;
    public bool DashRecargado;
    public GameObject Cabeza;
    public bool corriendo;
    public bool agachado;
    public float PosX;
    public float PosY;
    public float PosZ;
    public LayerMask LayerEnemigo;
    public GameObject cabeza;
    public bool Mueve = true;
    public bool MueveY = true;
    public float cont, DistanciaDaño;
    public bool CaeDaño;
    public float TiempoBarra = 0f;
    public int Dañocaida = 0;
    public Vector3 Posicion;
    public Vector3 velocidad;
    public Vector3 mover;
    public bool quieto;
    public TMP_Text contadorDash;
    
    public bool SaltoD;
    public bool SaltoN = true;
    public bool DashOn;

    void Start()
    {
        contadorDash.GetComponent<TMP_Text>().enabled = false;
        DashContador.CantidadDash = 3;
        Cabeza.SetActive(false);
         imagenBarra.color = Color.green;
    }

    private void FixedUpdate()
    {
        if (mana >= costoMana && corriendo)
        {
            mana -= costoMana;
        }
    }
    void Update()
    {
        if(CambiarPos)
        {
            CambioPos = true;
            CambiarPos = false;
            controlador.enabled = false;
        }
        else if(CambioPos)
        {
            
            controlador.enabled = true;
            CambioPos = false;
        }
        if(Nube)
        {
            Partic.Play();
            Nube = false;
        }
        else
        {
            Partic.Stop();
        }
        if(Alerta)
        {
            alerta.SetActive(true);
            ObjAlerta.GetComponent<Renderer>().material.color = Lejos;
            if(Physics.CheckSphere(transform.position, AlertaLejana, LayerEnemigo))
            {
            ObjAlerta.GetComponent<Renderer>().material.color = Medio;
                if(Physics.CheckSphere(transform.position, AlertaCercana, LayerEnemigo))
                {
                ObjAlerta.GetComponent<Renderer>().material.color = Cerca;
                }
            }
        }
        else
        {
            alerta.SetActive(false);
        }
        if(EnCombate)
        {
            cameraZoomIn = AumentoComCa;
            cameraZoomOut = AumentoComCo;
        }
        else
        {
            cameraZoomIn = 60;
            cameraZoomOut = 75;
        }
        if(Hablar)
        {
            if(animHablar)
            {
                anim.SetBool("Talk", true);
            }
            else
            {
                anim.SetBool("Quieto", true);
            }
            Camara.Activo = false;
            Mueve = false;
            Hablo = true;
        }
        else if(Hablo)
        {
            if(animHablar)
            {
               anim.SetBool("Talk", false);
            }
            else
            {
                anim.SetBool("Quieto", false);
            }
            
            Camara.Activo = true;
            Mueve = true;
            Hablo = false;
        }
        if(!Mueve)
        {
            corriendo = false;
        }
        


        acel_agachado = acel_caminar * 0.5f;
        
        visualMana.GetComponent<Slider>().value = mana;
        
        if(mover == Vector3.zero)
        {
            quieto = true;
            corriendo = false;
        }
        else
        {
            quieto = false;
        }
        if (quieto || corriendo == false)
        {
            StartCoroutine("tiempo");
            
        }
        if (corriendo)
        {
            StopAllCoroutines();
        }
       
        
        if (mana <= 5)
        {
            gastoCorrer = false;
            
            corriendo = false;
            
            
        }
        
        if (mana >= 800)
        {
            gastoCorrer = true;
        
            imagenBarra.color = Color.Lerp(imagenBarra.color, Color.green, TiempoBarra * 2 * Time.deltaTime);
        }
        if(mana <= 800 && corriendo)
        {
            imagenBarra.color = Color.Lerp(imagenBarra.color, Color.red, TiempoBarra * Time.deltaTime);
        }
        if (mana > 5 && corriendo)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, cameraZoomOut, TimeCamera * Time.deltaTime);
            anim.SetBool("Correr", true);
            acel_final = acel_correr;
        }
        if (!corriendo)
        {
            
            imagenBarra.color = Color.Lerp(imagenBarra.color, Color.green, TiempoBarra * Time.deltaTime);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, cameraZoomIn, TimeCamera * Time.deltaTime);
            anim.SetBool("Correr", false);
            acel_final = acel_caminar;
            
        }

        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        

        if (DashOn)
        {
            
            contadorDash.GetComponent<TMP_Text>().enabled = true;
            if (Input.GetKeyDown(KeyCode.LeftShift) && (PuedeDash || DashCount > DashAct) && mover != Vector3.zero)
            {
                DashAct++;
                StartCoroutine(Dash());
                DashContador.CantidadDash--;
                anim.SetBool("Dash", true);
            }
            else
            {
                anim.SetBool("Dash", false);
            }

            if (DashAct == 0)
            {
                
                PuedeDash = true;
            }
            else if (DashAct == 3)
            {
                PuedeDash = false;
            }

            if(DashAct == 3)
            {
                StartCoroutine("tiempoDash");
            }
            if(DashAct == 0)
            {
                StopAllCoroutines();
            }
        }  

        

        
        if(Mueve)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            controlador.Move(mover * acel_final * Time.deltaTime);
            mover = transform.right * x + transform.forward * z;
        
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", z);
        }
        if (!quieto && !Input.GetKey(KeyCode.LeftShift))
            {
                corriendo = false;
            }
         if (!quieto && Input.GetKey(KeyCode.LeftShift) && gastoCorrer && !agachado)
            {
                corriendo = true;
            }
        if (isGround)
        {
            jumpAct = 0;
            isgrounded = true;

            
            if (quieto)
            {
                
                acel_final = 0f;
            }
            if(MueveY)
            {
            if (Input.GetKey(KeyCode.LeftControl) || (ScriptCabeza.ContadorCabeza == 1))
            {
                anim.SetBool("Agachado", true);
                acel_final = acel_agachado;
                GetComponent<CharacterController>().height = 7.5f;
                GetComponent<CharacterController>().center = new Vector3( 0.0f,  -0.37f,  0.0f);
                Cabeza.SetActive(true);
                agachado = true;
            }
            else
            {
                if(ScriptCabeza.ContadorCabeza <= 0) 
                { 
                anim.SetBool("Agachado", false);
                acel_final = acel_caminar;
                GetComponent<CharacterController>().height = 11.3f;
                GetComponent<CharacterController>().center = new Vector3( 0.0f,  1.54f,  0.0f);
                Cabeza.SetActive(false);
                    agachado = false;
                }
            }
            
            if (SaltoN && (ScriptCabeza.ContadorCabeza == 0))
            {
                if (Input.GetButtonDown("Jump") && isGround)
                {
                    
                    velocidad.y = Mathf.Sqrt(jumpForce * -2 * gravedad);
                    
                    if(!Physics.CheckSphere(detecSalto.transform.position, detecSCont, groundMask))
                    {
                        anim.SetBool("Saltar", true);
                    }
                    
                    
                }
                SaltoD = false;
            }
            
            
            }
            anim.SetBool("TocoSuelo", true);
            Salto = false;
            if(Dañocaida >= 8)
            {
                GetComponent<Vida>().Disminuir(Dañocaida);  
                Dañocaida = 0;
            }

            if(Dañocaida <= 7)
            {
                Dañocaida = 0;
            }  
            anim.SetBool("LejosSuelo", false);  
            CaeDaño = false;
        }
        else
        {
            RaycastHit hit;
            if(!Physics.Raycast(groundCheck.transform.position, Vector3.down, out hit ,DistanciaDaño, groundMask))
            {
                CaeDaño = true;
                
            if(Physics.Raycast(groundCheck.transform.position, Vector3.down, out hit ,Mathf.Infinity, groundMask))
            {
              cont += 1 * Time.deltaTime;
              if(cont >= 0.09f)
              {
                 Dañocaida++;
                 cont = 0f;
              }
            }
            }
            Salto = true;
            EstoyCayendo();
            if(!Physics.Raycast(groundCheck.transform.position, Vector3.down, out hit ,10f, groundMask))
            {
                anim.SetBool("LejosSuelo", true);
            }
                CaeDaño = true;
            

        }
        if(MueveY)
        {
        if (SaltoD && Input.GetButtonDown("Jump") && (isgrounded || jumpCount > jumpAct) && (ScriptCabeza.ContadorCabeza == 0) )
            {

                velocidad.y = Mathf.Sqrt(jumpForce * -2 * gravedad);
                jumpAct++;
                isgrounded = false;
                anim.SetBool("Saltar", true);
                SaltoN = false;
            }
            if (isGround && velocidad.y < 0)
        {
            velocidad.y = -2f;
        }

        velocidad.y += gravedad * Time.deltaTime;
        controlador.Move(velocidad * Time.deltaTime);
        }
    }

    
    public void EstoyCayendo()
    {
        anim.SetBool("TocoSuelo", false);
        anim.SetBool("Saltar", false);
    } 
        

   

    IEnumerator tiempo()
    {
            while (true)
            {
            
                yield return new WaitForSecondsRealtime(0.005f);
                if (mana <= 800)
                {
                    mana += 0.2f * Time.deltaTime;
                    
                }
            
            }
     
    }
    
    
    IEnumerator tiempoDash()
    {
        while (true)
        {

            yield return new WaitForSecondsRealtime(15f);
            
            
                DashAct = 0;
                DashContador.CantidadDash = 3;
            
        }
    }


    IEnumerator Dash()
    {
        float starTime = Time.time;


        while(Time.time < starTime + dashTime)
        {
            controlador.Move(mover * dashSpeed * Time.deltaTime);

            yield return null;
           

        }
    }

    private void OnDrawGizmos() 
    {
      Gizmos.DrawWireSphere(cabeza.transform.position, 10f);
      Gizmos.DrawWireSphere(groundCheck.transform.position, groundDistance);
      Gizmos.DrawWireSphere(detecSalto.transform.position, detecSCont);
      Gizmos.DrawWireSphere(transform.position, AlertaCercana);
      Gizmos.DrawWireSphere(transform.position, AlertaLejana);
    }
}

