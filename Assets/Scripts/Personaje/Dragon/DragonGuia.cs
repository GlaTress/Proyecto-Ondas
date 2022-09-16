using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonGuia : MonoBehaviour
{
    public GameObject FlechaGuia, Portal;
    public FlechaGuia Flecha;
    public float cont = 0f;
    public float contDialogo = 0f;
    public float contador = 0f;
    public bool puedePortal, puedeIniciar, DialogoInicio,PuedeDialogo;
    public Comportamiento Drag;
    public ObjetoInteractivo objInter;
    public Dialogo DialogoDrag,DialogoDrag2;
    public RandomPos MovPadre;
    void Start()
    {
        objInter.interactuo = true;
    }

    
    void Update()
    {
     if(Drag.caso == 6)
        {
            cont += 1 * Time.deltaTime;
            if(cont >= 5 && cont <= 6)
            {
                
                DialogoDrag.inicioAuto = true;
                DialogoDrag.Inicio = true;
                DialogoDrag.Activo = true;
                PuedeDialogo = true;
            }
        }  

    
             if(!DialogoDrag.Inicio && PuedeDialogo)
            {
                DialogoDrag.inicioAuto = false;
                DialogoDrag.Activo = false;
                objInter.interactuo = false;
                Flecha.PosTarget = 12;
                FlechaGuia.SetActive(true);   
                puedeIniciar = true;  
                
                Drag.caso++;
                PuedeDialogo = false;
            }
    if(objInter.interactuo && !puedePortal && puedeIniciar)
        {
            contador += 1 * Time.deltaTime;
            
            if (!DialogoDrag2.Activo && contador >= 1 && contador <= 2  )
            {
                
                Flecha.PosTarget = 13;
                FlechaGuia.SetActive(false);   
                DialogoDrag2.Activo = true;
                DialogoDrag2.Inicio = true;
            }  
            
            
            if(!DialogoDrag2.Inicio)
            {
           
                DialogoDrag2.inicioAuto = false;
                DialogoDrag2.Activo = false;
                puedePortal = true; 
                contador = 0f;
                DialogoInicio = true;
            }
        }
    if(puedePortal)
    {
        contador += Time.deltaTime;
            
            
            if(!MovPadre.DialogoNPC[MovPadre.ValorDialogo].Inicio)
            {
                Portal.SetActive(true);
                
                MovPadre.ValorDialogo = 1;
                DialogoInicio = false;
            }
        
           
        
    }
    }
}
