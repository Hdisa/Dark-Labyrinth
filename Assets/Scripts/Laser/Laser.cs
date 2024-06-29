using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private int _maxBounce = 20;

    private int _count;
    private LineRenderer lr;
    [SerializeField] private Transform startPoint;
    private float laserDistance = 80f;
    [SerializeField] private LayerMask ignoreMask;
    public static Action OnHitTarget;
    private RaycastHit rayHit;
    private Ray ray;

    

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, startPoint.position);
    }
    private void Update()
    {
        ray = new(transform.position, transform.forward);
        if (Physics.Raycast(ray, out rayHit, laserDistance, ~ignoreMask))
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, rayHit.point);
            if(rayHit.collider.TryGetComponent(out Target target))
            {
                target.Hit();
                OnHitTarget?.Invoke();
            }
            if (rayHit.collider.CompareTag("Player"))
            {
                OnDeadReloadScene.onDead?.Invoke("Лазер");
            }
        }
        else
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position + transform.forward *laserDistance) ;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, ray.direction * laserDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rayHit.point, 0.23f);
    }
}
