using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaGuia : MonoBehaviour
{
    public float VelocidadDesp = 5f;
    public int PosTarget, PosNueva;
    public bool activo = false;
    public GameObject Target;
    public GameObject Pivot;
    public GameObject[] Tag;

    void Update()
    {
        if(activo)
        {
            Target.transform.position = Vector3.Lerp(Target.transform.position, Tag[PosTarget].transform.position, VelocidadDesp * Time.deltaTime);
            PosNueva = PosTarget + 1;
            
            Pivot.transform.LookAt(new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z));
            transform.LookAt(new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z));
        }
    }
        
}
