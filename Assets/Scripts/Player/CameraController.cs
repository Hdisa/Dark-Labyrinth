using UnityEngine;
public class CameraController : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public float maxYAngle = 80.0f;
    public float rotationX;

    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);
        
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.parent.Rotate(Vector3.up * (mouseX * sensitivity));
    }
}
