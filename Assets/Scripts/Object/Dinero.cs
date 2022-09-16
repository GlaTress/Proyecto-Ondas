using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dinero : MonoBehaviour
{

    [SerializeField] public TMP_Text Contador;
    public static int CantidadDinero;
    private int GuardaValor = CantidadDinero;
    Movimiento movimiento;



    void Start()
    {
        
        Contador.GetComponent<TMP_Text>();
        Contador.text = GuardaValor.ToString();
    }


    void Update()
    {
        Contador.text = CantidadDinero.ToString();

        
    }   
   
}
