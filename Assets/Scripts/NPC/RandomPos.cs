using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour
{
    public GameObject Jugador;
    public Dialogo[] DialogoNPC;
    public int ValorDialogo;
    public float velocidad;
    public bool Quieto;

    private float TiempoEspera;
    public float ComienzaTmpEspera;
    public Transform[] spots;
    private int RandValue;

    public Transform Objetivo, jugador;

    public Animator Anim;

    private void Start() {
        TiempoEspera = ComienzaTmpEspera;
        RandValue = Random.Range(0, spots.Length);
    }

    private void Update() {
        if(DialogoNPC[ValorDialogo].DialogoInicio)
        {
            Anim.SetBool("Hablar", false);
            transform.LookAt(new Vector3(jugador.position.x, transform.position.y, jugador.position.z));
        }
        if(!Quieto)
        {
        if(!DialogoNPC[ValorDialogo].DialogoInicio)
        {
        transform.position = Vector3.MoveTowards(transform.position, spots[RandValue].position, velocidad * Time.deltaTime);
        Anim.SetBool("Hablar", true);

        Objetivo = spots[RandValue];
        Vector3 direccion = Objetivo.position - transform.position;
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        transform.rotation = rotacion;
        }
        
            
        if(Vector3.Distance(transform.position, spots[RandValue].position) < 0.2f){
            if(TiempoEspera <= 0){
                RandValue = Random.Range(0, spots.Length);
                TiempoEspera = ComienzaTmpEspera;
                
            }else{
                TiempoEspera -= Time.deltaTime;
            }
        }
        }
    }
    void OnTriggerEnter(Collider colisor)
    {
        if (colisor.gameObject.CompareTag("Player"))
        {
            DialogoNPC[ValorDialogo].PuedeInterac = true;
            DialogoNPC[ValorDialogo].Activo = true;
            DialogoNPC[ValorDialogo].Inicio = true;
        }
       
    }
    void OnTriggerExit(Collider colisor)
    {
        if (colisor.gameObject.CompareTag("Player"))
        {
             DialogoNPC[ValorDialogo].PuedeInterac = false;
             DialogoNPC[ValorDialogo].Activo = false;
        }
        
       
    }
}
