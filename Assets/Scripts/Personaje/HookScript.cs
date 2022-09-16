using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HookScript : MonoBehaviour
{
    public GrapplingGun grappling;
    public CharacterController controlador;
    public LineRenderer lineRenderer;
    public Transform grapplingHook;
    public Transform grapplingHookEndPoint;
    public Transform handPos;
    public Transform playerBody;
    public Transform Enemy;
    public bool isGrapp = false;
    [SerializeField] private LayerMask GrappleLayer;
    [SerializeField] private float maxGrappleDistance;
    public float hookSpeed;
    public Vector3 offset;
    public bool tiempo = false;
    public bool uso = true;
    public GameObject Hook;

    

    public bool isShooting, isGrappling;
    public Vector3 hookPoint;

    private void Start()
    {
        isShooting = false;
        isGrappling = false;
        lineRenderer.enabled = false;
        Hook.SetActive(false);
    }

    private void Update()
    {
        

        if (grapplingHook.parent == handPos)
        {
            grapplingHook.localPosition = Vector3.zero;
        }
        if(uso)
        {
        if (Input.GetMouseButtonDown(1) && grappling.isGrappling == false && !tiempo)
        {
            
           ShootHook();
            
           lineRenderer.enabled = true;
           StartCoroutine(Espera());
            }

        if (isGrappling)
        {
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, hookPoint, hookSpeed * Time.deltaTime);
            
        }
                    
        }
    }

    private void LateUpdate()
    {
        if (lineRenderer.enabled)
        {
            lineRenderer.SetPosition(0, grapplingHookEndPoint.position);
            lineRenderer.SetPosition(1, handPos.position);
        }
    }


    private void ShootHook()
    {
        if (isShooting || isGrappling) return;

        isShooting = true;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isHook = Physics.Raycast(ray, out hit, maxGrappleDistance, GrappleLayer);
        
        if (isHook)
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<HookObject>().grapple = true;
                isGrapp = true;
            }

            
            hookPoint = hit.point;
            isGrappling = true;
            grapplingHook.parent = null;
            lineRenderer.enabled = true;
            grapplingHook.LookAt(hookPoint);
            Hook.SetActive(true);

            
        }
        
        isShooting = false;
    }
    

    IEnumerator Espera()
    {
        tiempo = true;
        yield return new WaitForSeconds(6);
        tiempo = false;
    }
}

