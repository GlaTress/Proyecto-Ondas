using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrimerReto : MonoBehaviour
{
[SerializeField] public TMP_Text Contador;
public bool Correr, Activo;
public int TiempoInicial, Pista, PistaMax, MaxJug;
public Dialogo DialogoGlimp;
public int PosTarget;
public GameObject ContadorVisual,PilipCorredor, Pilip;
public RandomPos PilipPos;
public bool Interactuo;
public PistaJugador JugPista;

 public Transform[] spots;
 public int Value;
 public Transform Objetivo;
 public int ValueMax;
public float velocidad, velocidadObjetivo;

public Movimiento JugMov;
public GameObject pistaInicial, pista;

public void Start()
{
    Contador.GetComponent<TMP_Text>();
}
public void Update()
{
    Contador.text = TiempoInicial.ToString();  
if(Activo)
{
   
if(!DialogoGlimp.Inicio)
{
if(!Interactuo)
{
JugMov.Camara.mouseX =  -290;
JugMov.Camara.mouseY =  0;
JugMov.transform.position = pistaInicial.transform.position;
JugMov.CambiarPos = true;
JugMov.Nube = true; 

StartCoroutine(Iniciar());

Interactuo = true;
Pista = 0;
Value = 0;
TiempoInicial = 3;
}

}
else
{
   Interactuo = false;
}

if(TiempoInicial == -1)
{
StopAllCoroutines();
DialogoGlimp.Inicio = true;
JugMov.Mueve = true;
Correr = true;
JugMov.Camara.Activo =  true;
TiempoInicial = 0;
}
if(Correr)
{
    
 Contador.text = JugPista.PistaJug.ToString();
 PilipCorredor.transform.position = Vector3.MoveTowards(PilipCorredor.transform.position, Objetivo.position, velocidad * Time.deltaTime);
 Objetivo.position = Vector3.Lerp(Objetivo.transform.position, spots[Value].transform.position, velocidadObjetivo * Time.deltaTime);
 
 transform.LookAt(new Vector3(Objetivo.position.x, transform.position.y, Objetivo.position.z));
 if(Vector3.Distance(PilipCorredor.transform.position, spots[Value].position) < 5f)
 {
     Value++;
     
 }
 if(Value == ValueMax)
 {
    Value = 0;
    Pista++;
 }
 if(Pista == PistaMax)
 {
    Correr = false;
    JugMov.CambiarPos = true;
    JugMov.transform.position = pista.transform.position;
    JugMov.Nube = true; 
    JugPista.PistaJug = 0;
    JugPista.ValorCheckPoints = 0;
    Pilip.SetActive(true);
 }
}
 if(JugPista.PistaJug == MaxJug)
 {
    PilipPos.ValorDialogo++;
    Activo = false;
    JugMov.CambiarPos = true;
    JugMov.transform.position = pista.transform.position;
    JugMov.Nube = true;
    JugPista.PistaJug = 0;
    PilipCorredor.SetActive(false);
    Pilip.SetActive(true);
 }
 }

IEnumerator Iniciar()
{
    yield return new WaitForSecondsRealtime(0.5f);
    JugMov.Mueve = false;
    Pilip.SetActive(false);
    JugMov.Camara.Activo =  false;
    ContadorVisual.SetActive(true);
    while(true)
    {
        yield return new WaitForSecondsRealtime(1f);
        TiempoInicial--;
    }
    
    
}
}
}
