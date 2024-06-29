using UnityEngine;

public class Rope : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other);
    }
}
