using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDragon : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public float time_rutinas;
    public Animator anim;
    public Quaternion Angulo;
    public float grado;
    public GameObject target;
    public bool atacando;
    public RangoBoss rango;
    public float speed;
    public GameObject[] hit;
    public int hitselected;

    public bool lanza_llamas;
    public List<GameObject> pool = new List<GameObject>();
    public GameObject fire;
    public GameObject cabeza;
    public GameObject point;
    private float cronometro2;

    public float Jump_distance;
    public bool direction_Skill;

    public int Fase = 1;
    public float HP_min;
    public float HP_max;
    public bool dead;


    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    
    void Update()
    {
        if( Vector3.Distance(transform.position, target.transform.position) < 15)
        {
            var lookpos = target.transform.position - transform.position;
            lookpos.y = 0;
            var rotation = Quaternion.LookRotation(lookpos);
            point.transform.LookAt(target.transform.position);
        }
    }
}
