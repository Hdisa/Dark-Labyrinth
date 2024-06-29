using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockTrap : MonoBehaviour
{
    private Rigidbody rb;
    public static Action onRopeTouched;
    // Start is called before the first frame update
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
        OnDeadReloadScene.onDead?.Invoke("ловушка веревка камень");
    }
    // Update is called once per frame
    void ActivateCutScene()
    {
        rb.useGravity = true;
    }
}
