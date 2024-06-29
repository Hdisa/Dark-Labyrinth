using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetPickedUp(bool isPickedUp)
    {
        rb.isKinematic = isPickedUp;
    }
}
