using UnityEngine;

public class ObjectGrabable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform grabPointTransform;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    
    public void Grab(Transform grabPointTransform)
    {
        this.grabPointTransform = grabPointTransform;
        objectRigidbody.useGravity = false;
    }

    public void Drop()
    {
        grabPointTransform = null;
        objectRigidbody.useGravity = true;
    }
    
    void FixedUpdate()
    {
        if (grabPointTransform != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, grabPointTransform.position, 20f*Time.deltaTime);
            objectRigidbody.MovePosition(newPosition);
        }
    }
}
