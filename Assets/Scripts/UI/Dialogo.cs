using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public bool inicioAuto, Inicio, VisibleInterac, PuedeInterac,Interactu, puedeAnimar;
    public Movimiento JugadorMov;
    public float typingTime = 0.05f;
    public bool Activo;
    public bool DialogoInicio;
    public int LineIndex;
    public GameObject PanelDialogo, DialogoInterac;
    public TMP_Text TextoDialogo;
   [SerializeField, TextArea(4, 6)] private string[] LineasDialogo;


    void Update()
    {
        if(PuedeInterac && !DialogoInicio)
        {
            DialogoInterac.SetActive(true);
            Interactu = true;
        }
        else if(Interactu)
        {
            DialogoInterac.SetActive(false);
            Interactu = false;
        }
        if(!DialogoInicio && Activo && (Input.GetButtonDown("Interactuar") || inicioAuto))
        {
            IniciarDialogo();
            if(puedeAnimar)
            {
                JugadorMov.animHablar = true;
            }
            else
            {
                JugadorMov.animHablar = false;
            }
        }
       if(Activo && Input.GetKeyDown(KeyCode.Return))
       {
        
        if(TextoDialogo.text == LineasDialogo[LineIndex] && DialogoInicio)
        {
            SiguienteDialogo();
        }
        else
        {
            StopAllCoroutines();
            TextoDialogo.text = LineasDialogo[LineIndex];
        }
       } 
    }
    public void IniciarDialogo()
    {
        Inicio = true;
        DialogoInicio = true;
        PanelDialogo.SetActive(true);
        LineIndex = 0;
        StartCoroutine(ShowLine());
        
        JugadorMov.Hablar = true;
    }
    public void SiguienteDialogo()
    {
        LineIndex++;
        if(LineIndex < LineasDialogo.Length)
        {
            StartCoroutine(ShowLine());
        }
        else 
        {
            Inicio = false;
            DialogoInicio = false;
            inicioAuto = false;
            PanelDialogo.SetActive(false);
            PuedeInterac = false;
            Interactu = false;
            Activo = false;
            JugadorMov.Hablar = false;
        }
    }
    public IEnumerator ShowLine()
    {
        TextoDialogo.text = string.Empty;

        foreach (char ch in LineasDialogo[LineIndex])
        {
            TextoDialogo.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
}
