using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DashContador : MonoBehaviour
{
    
    [SerializeField] public TMP_Text Dash;
    public static int CantidadDash;
    private int GuardaValor = CantidadDash;

    // Start is called before the first frame update
    void Start()
    {
        
        Dash.GetComponent<TMP_Text>();
        Dash.text = GuardaValor.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Dash.text = CantidadDash.ToString();
    }
}
