using System;
using UnityEngine;

public class RockTrap : MonoBehaviour
{
    private Rigidbody rb;
    public static Action onRopeTouched;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        onRopeTouched += ActivateCutScene;
    }
    private void OnDisable()
    {
        onRopeTouched -= ActivateCutScene;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Die();
        }
    }
    private void Die()
    {
        OnDeadReloadScene.onDead?.Invoke("������� ������� ������");
    }
    
    void ActivateCutScene()
    {
        rb.useGravity = true;
    }
}