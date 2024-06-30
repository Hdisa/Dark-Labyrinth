using UnityEngine;

public class Rope : MonoBehaviour
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
        RockTrap.onRopeTouched?.Invoke();
    }
}