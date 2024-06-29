using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PitTrip : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Die();
        }
    }
    private void Die()
    {
        OnDeadReloadScene.onDead?.Invoke("ловушка яма");
    }
}
