using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecJug : MonoBehaviour
{
    public bool PuedeDetec;
    public bool Detecto;
    public float TiempoDetec;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PuedeDetec)
        {
            if(TiempoDetec >= 1)
            {
                Detecto = true;
            }
            if(TiempoDetec == 0)
            {
                Detecto = false;
            }
        }
    }
    void OnTriggerStay(Collider colisor)
    {
        if (colisor.gameObject.CompareTag("Player") && !Detecto)
        {
            TiempoDetec += 1 * Time.deltaTime;

        }
      
    }
    void OnTriggerExit(Collider colisor)
    {
      if (colisor.gameObject.CompareTag("Player"))
        {
            TiempoDetec = 0;

        }
    }

}
