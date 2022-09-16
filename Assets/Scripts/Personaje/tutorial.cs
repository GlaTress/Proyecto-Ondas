using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public bool Activa,ActivarDrag, puedeFlecha;
    public Dialogo dialogoTut, dialogoJug, dialogoJug2, dialogoJug3;
    public bool PuedeInterac;
    public Baston baston;
    public ObjetoInteractivo objInterac;
    public float ContFlecha = 0.0f;
    public FlechaGuia flecha;
    public GameObject FlechaGuia;
    public Movimiento MovJugador;
    public CamaraControl MovCam;
    public GameObject TutMouse, TutFlecha ,TutMov, TutDialogo, TutBast, TutMana, TutCaida, Dragon;
    public bool FlechaActive = false;
    public bool FlechaInicialActive = false;
    public bool TutM,TutC, TutD;
    public float cont = 0f;
    public float contInicial = 0f;
    public bool inicio = false;
    public bool PuedeDrag = true;
    public bool Activo = true;
    public ObjetoInteractivo objeto;
    public iniciarCinematica Cinematica, Cinematica2;
    public bool inicioCinematica, InicioDrag;
    
    public CambioArmas cambioArmas;

    void Start()
    {
        objeto.interactuo = true;
        
         cambioArmas.uso = false;
            flecha.PosTarget = 0;
    }

    void Update()
    {
        if(TutC)
        {
            contInicial += 1 * Time.deltaTime;

            if(contInicial > 2)
            {
                TutMouse.SetActive(true);
                
                contInicial = 0;
                inicio = true;
            }
        }
        if(inicio && TutC && (MovCam.mouseY < -20 || MovCam.mouseY > 20 ||MovCam.mouseX < -20 || MovCam.mouseX > 20))
        {
            cont += 1 * Time.deltaTime;
            if(cont > 2)
            {
                
            TutMouse.SetActive(false);
            cont = 0f;
            TutC = false;
            }
            
        }
        if(!Activo && Activa)
        {
            TutM = false;
            objeto.interactuo = false;
            TutMouse.SetActive(false);
            TutC = false;
            TutMov.SetActive(false);
            TutD = false;
            dialogoTut.Activo = false;
            FlechaGuia.SetActive(false);
            TutFlecha.SetActive(false);
            Activa = false;
        }
        if(TutM && !TutC)
        {
            
            contInicial += 1 * Time.deltaTime;

            if(contInicial > 1)
            {
                TutMov.SetActive(true);
                contInicial = 0f;
            }
        }
        if(TutM && !TutC &&  !MovJugador.quieto)
        {
            
           cont += 1 * Time.deltaTime;
            if(cont > 2)
            {
                
            TutFlecha.SetActive(true);
            TutMov.SetActive(false);
            TutM = false;
            objeto.interactuo = false;
            
            FlechaGuia.SetActive(true);
            Cinematica.inicio = true;
            flecha.PosTarget = 0;
            }
            
        }
        
        if( !TutM && !TutD && PuedeDrag)
        {
            if(Vector3.Distance(transform.position, flecha.Target.transform.position) < 20)
            {
                
            FlechaGuia.SetActive(false);
            
            TutFlecha.SetActive(false);
            puedeFlecha = true;    
            }
            else if(puedeFlecha)
            {
                FlechaGuia.SetActive(true);
            
            TutFlecha.SetActive(true);
            puedeFlecha = false;
            }
            if(objeto.interactuo == true)
            {
                FlechaGuia.SetActive(false);
            
                TutFlecha.SetActive(false);
                TutMov.SetActive(false);
                flecha.PosTarget++;
                ContFlecha += 1 * Time.deltaTime;
                if(ContFlecha <= 2)
                {
                    
                TutD = true;
                PuedeDrag = false;
                ContFlecha = 0f;
                
                ContFlecha = 0.0f;
                
                }
            }
                
            
        }
        if(TutD)
        {
            ////
            FlechaGuia.SetActive(true);

            ContFlecha += 1 * Time.deltaTime;
            if(ContFlecha >= 2)
            {
                FlechaActive = true;
                ContFlecha = 0.0f;
                
            }
            if(FlechaActive && flecha.PosTarget <= 2)
            {
                if(Vector3.Distance(transform.position, flecha.Target.transform.position) < 60f)
                {
                flecha.PosTarget++;
                FlechaActive = false;
                }
                else if (Vector3.Distance(transform.position, flecha.Tag[flecha.PosNueva].transform.position) < 200f)
                {
                flecha.PosTarget++;
                FlechaActive = false;
                }
            
            }
            cont+= 1 * Time.deltaTime;
            if(cont >= 1 &&  !dialogoTut.Activo)
            {
                dialogoTut.Activo = true;
                TutDialogo.SetActive(true);
            }
            if(!dialogoTut.Inicio)
            {
                
                TutDialogo.SetActive(false);
                dialogoTut.Activo = false;
                dialogoTut.Inicio = false;
                dialogoTut.inicioAuto = false;
            }
        }
        else if(!TutM && !TutC)
        {
            Activo = true;
        }

        if(PuedeInterac)
        {
             if(!dialogoJug2.Activo && !objInterac.interactuo)
            {
                dialogoJug2.Activo = true;
            }
            if(!dialogoJug2.Inicio && dialogoJug2.Activo)
            {
                dialogoJug2.Activo = false;
                dialogoJug2.Inicio = false;
                dialogoJug2.inicioAuto = false;
            }
           
        if(objInterac.interactuo)
        {
             ContFlecha += 1 * Time.deltaTime;
            if(ContFlecha >= 2)
            {
                FlechaActive = true;
                ContFlecha = 0.0f;
                
            }
            
            if(FlechaActive && flecha.PosTarget <= 11)
            {
                if(Vector3.Distance(transform.position, flecha.Target.transform.position) < 60f)
                {
                flecha.PosTarget++;
                FlechaActive = false;
                }
                else if (Vector3.Distance(transform.position, flecha.Tag[flecha.PosNueva].transform.position) < 200f)
                {
                flecha.PosTarget++;
                FlechaActive = false;
                }
            
            }

            if(!dialogoJug3.Inicio)
                 {
                     dialogoJug3.Activo = false;
                     dialogoJug3.Inicio = false;
                     dialogoJug3.inicioAuto = false;
                 }
            if(flecha.PosTarget == 11)
            {
                FlechaGuia.SetActive(false);
            }
            if(dialogoJug.Inicio && !dialogoTut.Activo)
            {
                InicioDrag = true;
                flecha.PosTarget = 4;
                FlechaActive = true;
                FlechaGuia.SetActive(true); 
            dialogoJug.Activo = true;
            cont = 0f;
            }
             if(!dialogoJug.Inicio && dialogoJug.Activo)
            {
                dialogoJug.Activo = false;
                dialogoJug.Inicio = false;
                dialogoJug.inicioAuto = false;
            }
            if(!dialogoJug.Inicio && !dialogoJug.Activo)
            {
                
            cont += 1 * Time.deltaTime;
            }
            if(cont >= 1 && cont <= 6 )
            {
                TutBast.SetActive(true);
            }
            if(cont>= 8)
            {
                
               TutBast.SetActive(false);
            }
            if(cont >=9 && cont <= 17)
            {
                TutMana.SetActive(true);
            }
            if(cont>= 18)
            {
                
                TutMana.SetActive(false);
            }

            if(cont >= 19 && cont <= 25)
            {
                TutCaida.SetActive(true);
                
            }
            if(cont>= 26)
            {
                
                TutCaida.SetActive(false);
            }
            
                
            
           
            baston.uso = true;
            cambioArmas.EspacioArma2.SetActive(true);
            
        }

        }
    }
    void OnTriggerStay(Collider colisor)
    {
        if (colisor.gameObject.CompareTag("Cinematica") && inicioCinematica)
        {
            Cinematica2.inicio = true;
            inicioCinematica = false;
        }
        if (colisor.gameObject.CompareTag("EntrarAlerta") && InicioDrag && objInterac.interactuo)
        {
           MovJugador.Alerta = true;
           InicioDrag = false;
           dialogoJug3.Activo = true;
           
           FlechaGuia.SetActive(false);      
        }
         if (colisor.gameObject.CompareTag("EntroTrigger") && !ActivarDrag)
        {
            MovJugador.Nube = true;
            Dragon.SetActive(true);  
            ActivarDrag = true;
        }

        
    }
}
