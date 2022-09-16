using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeyendaImagen8 : MonoBehaviour
{
    public GameObject UICHAT;
    public GameObject LeyendaCanvas;
    private bool InRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InRange){
            UICHAT.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
            LeyendaCanvas.SetActive(true); //MOSTRAR LA LEYENDA DE LA IMAGEN CUANDO SE PRESIONE E
            UICHAT.SetActive(false);
            }
        }
    }
    private void OnTriggerStay(Collider other) {
        InRange = true;
        
        }
    private void OnTriggerExit(Collider other) {
        InRange = false;
        UICHAT.SetActive(false);
        LeyendaCanvas.SetActive(false);
    }
}
