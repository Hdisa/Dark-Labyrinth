using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private RockTrap rock;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var rb = rock.GetComponent<Rigidbody>();
            rb.useGravity = true;
        }
    }
}
