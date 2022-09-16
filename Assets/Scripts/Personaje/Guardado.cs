using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardado : MonoBehaviour
{
    public float PosX;
    public float PosY;
    public float PosZ;

    public Vector3 Posicion;
    void Start()
    {
        //CargarDatos();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            GuardarDatos();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CargarDatos();
        } 
    }

    public void GuardarDatos()
    {
        PlayerPrefs.SetFloat("PosicionX", transform.position.x);
        PlayerPrefs.SetFloat("PosicionY", transform.position.y);
        PlayerPrefs.SetFloat("PosicionZ", transform.position.z);
    }
    public void CargarDatos()
    {
        PosX = PlayerPrefs.GetFloat("PosicionX");
        PosY = PlayerPrefs.GetFloat("PosicionY");
        PosZ = PlayerPrefs.GetFloat("PosicionZ");

        Posicion.x = PosX;
        Posicion.y = PosY;
        Posicion.z = PosZ;

        transform.position = Posicion;
    }
}
