using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLibre : MonoBehaviour
{
    
    public static float Sensibilidad;
    public Transform JugadorMesh; //Referenciar grupo/objeto jugador

    public int _Invertir;

    float RotacionX = 0f;
    
    // Start is called before the first frame update

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Sensibilidad = PlayerPrefs.GetFloat("MasterSens");
        _Invertir = PlayerPrefs.GetInt("InvertY", 0);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensibilidad;
        float mouseY = Input.GetAxis("Mouse Y") * Sensibilidad;

        if(_Invertir == 1){
            RotacionX += mouseY;
        }
        else{
            RotacionX -= mouseY;
        }
        
        RotacionX = Mathf.Clamp(RotacionX, -70f, 70f);
        transform.localRotation = Quaternion.Euler(RotacionX, 0f, 0f);
        JugadorMesh.Rotate(Vector3.up * mouseX);
    }
}
