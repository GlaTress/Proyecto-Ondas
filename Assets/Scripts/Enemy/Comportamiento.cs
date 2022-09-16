using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Comportamiento : MonoBehaviour
{
   
   public Transform[] posLanzar;
   public int ValorPos;
   public float velocidadLanzado, SuavizaCam;
   public DetecJug detecJug;
   public float velocidad, velocidadObjetivo;
   public Vector3 DistFrente;

    public float TiempoEspera;
    public float ComienzaTmpEspera;
    public Transform[] spots;
    public int Value;
    public int ValueMax;

   public Transform Objetivo;

   public bool lanzarJugador, LanzoJugador;
   public bool patrullar;
   public bool JugadorFrente;
   public bool CercanoJug;
   public float LejosJug, CercaJug;
   public bool SeguirJug;
   public GameObject PostPro1, PostPro2, NPC,Particle, Particle2;
   public Transform Estatua, SpotInicial;
   public  Dialogo dialogoScript,dialogoScript2;
   public Transform PATASDetec;
   public Animator anim;
   public float cotCol = 0f;
   public float TamañoPies = 0f;
   public MeshCollider colision;
   public tutorial Tut;
   public float Tamaño = 0f;
   public bool cerca = false;
    public bool colisiono = false;
    public GameObject Jugador;
    public GameObject Menupausa;
    public GameObject Dragon;
    public GameObject DragonAliado;
    public GameObject Limites;
    public GameObject Pies;
    public GameObject CanvasTiempo;
    public GameObject cola;
    public Movimiento JugadorMov;
    public bool Activo = false;
    public bool suelo = true;
    public bool encima = false;
    public bool Aumenta = false;
    public Quaternion angulo;
    public float grado;
    public int caso = 0;
    public float cronometro = 0;
    public float Espera = 0;
    public int fase = 0;
    
    public float cronometroCola = 0;
    
    public float Gravedad = -500;
    public float Salto = 40;
    public float vel;
    public float speed = 1.0f;
    public float Journey = 1.0f;
    private float startTime;
    public bool salto = false;
    public bool Disparo = false;
    public bool Finaliza = true;
    public LayerMask LayerJugador;
    public LayerMask LayerGround;
    public LayerMask LayerEncima;
    public GameObject Tutorial_1,Tutorial_2,Tutorial_3, Tutorial_Alerta, TutDisparo;
    public TMP_Text Fase1,Fase2,Fase3;
    public GameObject BalaInicio;
    public GameObject BalaPrefab;
    public float BalaVelocidad;

    
    public bool reset = true;


    Vector3 Impulso;

    public void Start() 
    {
      
         CanvasTiempo.SetActive(false);
      
         Fase1.GetComponent<TMP_Text>();
         Fase2.GetComponent<TMP_Text>();
         Fase3.GetComponent<TMP_Text>();
      
         DragonAliado.SetActive(false);
    } 

    public void Update()
    {

       if(patrullar)
                  {

                  Limites.SetActive(false);
                  JugadorFrente = false;
                  transform.position = Vector3.MoveTowards(transform.position, Objetivo.position, velocidad * Time.deltaTime);
                  Objetivo.position = Vector3.Lerp(Objetivo.transform.position, spots[Value].transform.position, velocidadObjetivo * Time.deltaTime);
                  
                  
                  transform.LookAt(new Vector3(Objetivo.position.x, transform.position.y, Objetivo.position.z));
                  detecJug.PuedeDetec = true;
                   if(Value == ValueMax)
                  {
                     Value = 0;
                  }
                  if(Vector3.Distance(transform.position, spots[Value].position) < 80f)
                  {
                  if(TiempoEspera <= 0)
                  {
                      Value++;
                      TiempoEspera = ComienzaTmpEspera;
                      
                  }
                  else
                  {
                      TiempoEspera -= Time.deltaTime;
                  }
                  }
                  }
      if(lanzarJugador)
      {
         detecJug.TiempoDetec = 0f;
         detecJug.Detecto = false;
         JugadorFrente = false;
         patrullar = true;
         JugadorMov.controlador.enabled = false;
         JugadorMov.transform.position = Vector3.MoveTowards(JugadorMov.transform.position, posLanzar[ValorPos].position, velocidadLanzado * Time.deltaTime);
         if(Vector3.Distance(JugadorMov.transform.position ,posLanzar[ValorPos].position) < 20)
         {
            lanzarJugador = false;
         }
         LanzoJugador = true;
      }
      else if(LanzoJugador)
      {
         LanzoJugador = false;
         JugadorMov.controlador.enabled = true;
      }
      if(SeguirJug)
      {
         if(CercanoJug)
         {
            transform.LookAt(new Vector3(Jugador.transform.position.x, transform.position.y, Jugador.transform.position.z));
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Jugador.transform.position.x, transform.position.y, Jugador.transform.position.z), 200 * Time.deltaTime);
         }
         if(!Physics.CheckSphere(transform.position, LejosJug, LayerJugador))
         {
            CercanoJug = true;
             
         }
         if(Physics.CheckSphere(transform.position, CercaJug, LayerJugador))
            {
               CercanoJug = false;
            }
      }
     
      if(reset)
      {
         Tutorial_1.SetActive(false);
         Tutorial_2.SetActive(false);
         Tutorial_3.SetActive(false);
         reset = false;
      }
      RaycastHit hit;
      if(salto && !suelo && Physics.Raycast(Pies.transform.position, Vector3.down, out hit, Mathf.Infinity, LayerJugador))
      {
         encima = true;
      }
       if (salto && !encima)
         {  
          Aumenta = true;
          Finaliza = false;
          suelo = false;
          Impulso.y = Mathf.Sqrt(Salto * -2 * Gravedad);
          transform.Translate(Impulso * 2 * Time.deltaTime);
          
         transform.LookAt(new Vector3(Jugador.transform.position.x, transform.position.y, Jugador.transform.position.z));          
          transform.position = Vector3.MoveTowards(transform.position, new Vector3(Jugador.transform.position.x, transform.position.y, Jugador.transform.position.z), vel * Time.deltaTime);
          }
      if(encima)
      {
         colision.enabled = false;
         Impulso.y += Gravedad * Time.deltaTime;
         transform.Translate(Impulso * 2 * Time.deltaTime);
         if(fase == 0)
      {
         Time.timeScale = 0.5f;
         CanvasTiempo.SetActive(true);
         
      }
      }

      

      if(encima && Physics.CheckSphere(Pies.transform.position, 100f, LayerGround))
      {
         salto = false;
      }

      if(encima && Physics.CheckSphere(PATASDetec.transform.position, TamañoPies, LayerGround))
      {
         transform.position = new Vector3(this.transform.position.x, y: 34.7f, transform.position.z);
         Time.timeScale = 1f;
         CanvasTiempo.SetActive(false);
         encima = false;
         suelo = true;
         Finaliza = true;
         
      }
      if(suelo && caso == 0 && Activo)
      {
         cotCol += 1 * Time.deltaTime;
         if(cotCol >= 0.8)
         {
            colision.enabled = true;
            cotCol = 0;
         }
      }
      if(Physics.Raycast(Pies.transform.position,  Vector3.down, out hit, 4f, LayerJugador))
      {
         
         JugadorMov.controlador.Move(Vector3.forward * 500f * Time.deltaTime);
          JugadorMov.GetComponent<Vida>().Disminuir(15);
         
      }

      

      if(!Activo && Tut.ActivarDrag)
               {
                  
                  Tut.TutD = false;
                  if(dialogoScript.Inicio)
                  {
                  JugadorMov.Camara.mouseX = Mathf.Lerp(JugadorMov.Camara.mouseX, -315, SuavizaCam * Time.deltaTime);
                  JugadorMov.Camara.mouseY = Mathf.Lerp(JugadorMov.Camara.mouseY, 0, SuavizaCam * 0.5f * Time.deltaTime);
                  dialogoScript.Activo = true;
                  JugadorMov.Nube = false;

                  }
                  Tut.Activo = false;
                  
                  if(!dialogoScript.Inicio)
                  {
                     
                     Tut.Activo = false;
                     Activo = true;
                     JugadorMov.Nube = true;
                     JugadorMov.CambiarPos = true;
                     JugadorMov.transform.position = SpotInicial.position;
                     Tutorial_Alerta.SetActive(true);
                  }

                     
               }
               


         if(Activo)
         {
                  
                switch (caso)
                {
                  case 0:
                  JugadorMov.Alerta = true;
                  JugadorMov.EnCombate = true;
                  Tutorial_1.SetActive(true);
                  Menupausa.SetActive(false);
                 
                  if(Finaliza)
                  {
                     
                     Limites.SetActive(true);
                     encima = false;
                     cronometro += 1 * Time.deltaTime;
                     if(cronometro > 2)
                     {
                     salto = true;
                     cronometro = 0;
                     }
                  }
                  
                  if(Aumenta && encima && JugadorMov.corriendo)
                  {
                     
                  
                  Tutorial_Alerta.SetActive(false);
                  fase++;
                  cronometro = 0;
                  Aumenta = false;
                  }
                   
                  switch (fase)
                  {
                     case 1:
                     Fase1.text = "Presiona Shift + W  Para correr de la caida del Dragon (1/3)";
                     break;
                     case 2:
                     Fase1.text = "Presiona Shift + W  Para correr de la caida del Dragon (2/3)";
                     break;
                     case 3:
                     Aumenta = false;
                     Fase1.text = "Presiona Shift + W  Para correr de la caida del Dragon (3/3)";
                     break;
                  }

                  if(fase == 3)
                  {
                     
                     Espera++;
                     if(Espera >= 2 && suelo)
                     {
                        caso++;
                        fase = 0;
                        Tutorial_1.SetActive(false);
                        Espera = 0; 
                        transform.position = new Vector3(this.transform.position.x, y: 34.7f, transform.position.z);
                        reset = true;
                        
                       colision.enabled = true;
                     }
                     
                  }
                  
                  break;
                  
                  case 1:
                  SeguirJug = true;
                  Tutorial_2.SetActive(true);
                  transform.LookAt(new Vector3(Jugador.transform.position.x, transform.position.y, Jugador.transform.position.z));
                  BalaInicio.transform.LookAt(new Vector3(Jugador.transform.position.x, Jugador.transform.position.y, Jugador.transform.position.z));
                  transform.position = new Vector3(this.transform.position.x, y: 34.7f, transform.position.z);
                  if(!CercanoJug)
                  {
                  cronometro += 1 * Time.deltaTime;
                  }
                  if(cronometro == 0)
                  {
                     Disparo = false;
                     CanvasTiempo.SetActive(false);
                         Time.timeScale = 1f;
                     
                  }

                  if(cronometro > 1.5)
                  {
                     if(fase == 0)
                     {
                        JugadorMov.Mueve = false;
                          CanvasTiempo.SetActive(true);
                         Time.timeScale = 0.4f;
                     }
                  }

                  if(cronometro > 2)
                  {
                     Shoot();
                     cronometro = 0;
                     Aumenta = true;
                  }

                  if(fase == 1)
                  {
                     
                     JugadorMov.Mueve = true;
                  }
                  if(Aumenta && Disparo && JugadorMov.agachado)
                  {
                      CanvasTiempo.SetActive(false);
                      Time.timeScale = 1f;
                     cronometro = 0;
                     fase++;
                     Aumenta = false;
                  }

                  if(fase == 3)
                  {
                     Espera++;
                     if(Espera >= 3)
                     {
                        caso++;
                        fase = 0;
                        
                        Tutorial_2.SetActive(false);
                        Espera = 0;  
                        reset = true;
                        Aumenta = false;
                     }
                  }
                  switch (fase)
                  {
                     case 1:
                     Fase2.text = "Presiona LeftControl para agacharte y cubrirte el ataque (1/3)";
                     break;
                     case 2:
                     Fase2.text = "Presiona LeftControl para agacharte y cubrirte el ataque (2/3)";
                     break;
                     case 3:
                     Fase2.text = "Presiona LeftControl para agacharte y cubrirte el ataque (3/3)";
                     break;
                  }

                  
                  break;

                  case 2:
                  Tutorial_3.SetActive(true);
                  cola.transform.localScale = new Vector3( Tamaño, -0.1f , Tamaño);
                  if(!CercanoJug)
                  {
                     
                  cronometroCola += 1 * Time.deltaTime;
                  }

                  if(cronometroCola > 2.7f)
                  {
                     if(fase == 0)
                     {
                         CanvasTiempo.SetActive(true);
                         Time.timeScale = 0.3f;
                     }
                     if(JugadorMov.isGround == false)
                     {
                        Aumenta = false;
                     }
                  }

                  if(cronometroCola > 3)
                  {  
                     cola.SetActive(true);
                     Tamaño += 10 * Time.deltaTime;
                     
                        
                     
                  }
                  if(cronometroCola <= 0.5)
                  {
                     
                     if(JugadorMov.isGround == true)
                     {
                        Aumenta = true;
                     }
                     
                     Tamaño = 0f;
                     cola.SetActive(false);
                     CanvasTiempo.SetActive(false);
                     Time.timeScale = 1f;
                  }
                  if(cronometroCola > 4)
                  {
                     cronometroCola = 0;
                      
                  }
                  

                  if(Aumenta && cronometroCola > 2.7 && Input.GetButtonDown("Jump"))
                  {
                     
                     fase++;
                     Aumenta = false;
                  }
                  if(fase == 3 && cronometroCola <= 0.5)
                  {
                     Espera++;
                     if(Espera >= 3)
                     {
                        
                        cronometroCola = 0;
                        caso++;
                        fase = 0;
                        reset = true;
                        Espera = 0;  
                     }
                  }

                  switch (fase)
                  {
                     case 1:
                     Fase3.text = "Presiona Espacio para saltar y evadir su ataque (1/3)";
                     break;
                     case 2:
                     Fase3.text = "Presiona Espacio para saltar y evadir su ataque (2/3)";
                     break;
                     case 3:
                     Fase3.text = "Presiona Espacio para saltar y evadir su ataque (3/3)";
                     break;
                  }


                  break;
                  
                  case 3:
                  cronometroCola = 0;
                  cola.SetActive(false);  
                  transform.LookAt(new Vector3(Jugador.transform.position.x, transform.position.y, Jugador.transform.position.z));
                  transform.position = Vector3.MoveTowards(transform.position, new Vector3(Jugador.transform.position.x, transform.position.y, Jugador.transform.position.z), 200 * Time.deltaTime);

                 if(Vector3.Distance(transform.position, Jugador.transform.position) < 60f)
                  {
                    Limites.SetActive(false);
                    caso++;
                  }
                   
                  break;
                  case 4:
                  
                  SeguirJug = false;
                  JugadorMov.CambiarPos = true;
                  JugadorMov.transform.position = Estatua.transform.position;
                  Tut.objInterac.interactuo = false;
                  patrullar = true;
                  detecJug.TiempoDetec = 0f;
                  detecJug.Detecto = false;
                  JugadorFrente = false;
                  patrullar = true;
                  caso++;
                  JugadorMov.Alerta = false;
                  break;
                  case 5:

                  
                  Tut.PuedeInterac = true;
                 
                  JugadorMov.EnCombate = false;
                  
                  if(detecJug.Detecto && !cerca)
                  {
                     
                     ValorPos = Random.Range(0, posLanzar.Length);
                     patrullar = false;
                     JugadorFrente = true;
                      
                  }
                  if(JugadorFrente)
                  {
                     Limites.SetActive(true);
                     transform.LookAt(new Vector3(Jugador.transform.position.x, transform.position.y, Jugador.transform.position.z));
                     transform.position = Vector3.MoveTowards(transform.position, new Vector3(Jugador.transform.position.x, transform.position.y, Jugador.transform.position.z), 200 * Time.deltaTime);

                     if(Vector3.Distance(transform.position, Jugador.transform.position) < 100)
                  {
                     
                     detecJug.TiempoDetec = 0;
                     lanzarJugador = true;
                     cerca = false;
                  }
                     
                  }
                  if(Vector3.Distance(transform.position, Jugador.transform.position) < 80 && !JugadorFrente)
                  {
                     cerca = true;
                  }
                  else 
                  {
                     cerca = false;
                  }
                  if(cerca && !JugadorFrente && Tut.objInterac.interactuo)
                  {
                     Time.timeScale = 0.1f;
                     CanvasTiempo.SetActive(true);
                     Tut.FlechaGuia.SetActive(false);
                     Tut.FlechaActive = false;
                     TutDisparo.SetActive(true);
                  }
                 else
                  {
                     Time.timeScale = 1f;
                     
                     CanvasTiempo.SetActive(false);
                  }
                  if(colisiono && Tut.ActivarDrag && !JugadorFrente)
                  {
                     Time.timeScale = 1f;
                     CanvasTiempo.SetActive(false);
                     lanzarJugador = false;
                     patrullar = false;
                     TutDisparo.SetActive(false);
                     
                  dialogoScript2.Activo = true;
                  JugadorMov.Alerta = false;
                  
                  }
                  if(!dialogoScript2.Inicio && dialogoScript2.Activo)
                  {
                     dialogoScript2.Activo = false;
                     dialogoScript2.inicioAuto = false;

                     
                     caso++;

                     Particle2.SetActive(true);
                     Particle.SetActive(false);
                     NPC.SetActive(true);
                     PostPro1.SetActive(false);
                     PostPro2.SetActive(true);
                     Limites.SetActive(false);
                     Dragon.SetActive(false);
                     Menupausa.SetActive(true);
                  }
                  
                  
                     
                     
                     
                  
                  
                  
                  
                  break;
                }
                   
                  


        
          }

        
            
    }         
        
    

    public void Shoot()
    {

        
        GameObject BalaTemporal = Instantiate(BalaPrefab, BalaInicio.transform.position, BalaInicio.transform.rotation) as GameObject;

        
        Rigidbody rb = BalaTemporal.GetComponent<Rigidbody>();
        Disparo = true;

        
        rb.AddForce(transform.forward * BalaVelocidad);

        Destroy(BalaTemporal, 6f);
        
    }

    private void OnDrawGizmos() 
    {
      Gizmos.DrawWireSphere(transform.position, 100f);
      Gizmos.DrawWireSphere(transform.position, LejosJug);
      Gizmos.DrawWireSphere(transform.position, CercaJug);
      Gizmos.DrawWireSphere(PATASDetec.transform.position, TamañoPies);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DamageEnemy"))
        {
            colisiono = true;
        }
    }
}