using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GrapplingGun : MonoBehaviour
{
    public HookScript grappling;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private CharacterController controlador;
    [SerializeField] private Transform grapplingHook;

    [SerializeField] private Transform grapplingHookEndPoint;
    [SerializeField] private Transform handPos;
    [SerializeField] private Transform playerBody;
    [SerializeField] private MeshRenderer Grappling;
    [SerializeField] private LayerMask GrappleLayer;
    [SerializeField] private float maxGrappleDistance;
    [SerializeField] private float hookSpeed;
    [SerializeField] private Vector3 offset;

    public bool uso = true;

   

    public bool isShooting, isGrappling;
    private Vector3 hookPoint;

    private void Start()
    {
        isShooting = false;
        isGrappling = false;
        lineRenderer.enabled = false;
        Grappling.enabled = false;
    }
    
    private void Update()
    {
        
        
        if(grapplingHook.parent == handPos)
        {
            grapplingHook.localPosition = Vector3.zero;
        }
        if(uso)
        {
        if (Input.GetMouseButtonDown(0) && grappling.isGrappling == false)
        {
            ShootHook();
            
        }


        if (isGrappling)
        {
            
            
            grapplingHook.position = Vector3.Lerp(grapplingHook.position, hookPoint, hookSpeed * Time.deltaTime);
            if (Vector3.Distance(grapplingHook.position, hookPoint) < 0.5f)
            {
                controlador.enabled = false;
                playerBody.position = Vector3.Lerp(playerBody.position, hookPoint - offset, hookSpeed * Time.deltaTime);
                if (Vector3.Distance(playerBody.position, hookPoint - offset) < 0.5f)
                {
                    Grappling.enabled = false;
                    controlador.enabled = true;
                    isGrappling = false;
                    grapplingHook.SetParent(handPos);
                    lineRenderer.enabled = false;
                }
            }
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
        if(Physics.Raycast(ray, out hit, maxGrappleDistance, GrappleLayer))
        {
            hookPoint = hit.point;
            isGrappling = true;
            grapplingHook.parent = null;
            grapplingHook.LookAt(hookPoint);
            lineRenderer.enabled = true;
            Grappling.enabled = true;
        }

        isShooting = false;
    }
}
