using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2.0f;
    [SerializeField] private float maxYAngle = 80.0f;
    private float rotationX;
    private bool canRotate = true;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        RockTrap.onRopeTouched += ActivateRopeTrapCutScene;
    }
    private void OnDisable()
    {
        RockTrap.onRopeTouched -= ActivateRopeTrapCutScene;
    }
    void Update()
    {
        if (canRotate)
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");

            rotationX -= mouseY * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);

            transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.parent.Rotate(Vector3.up * (mouseX * sensitivity));
        }
    }
    void ActivateRopeTrapCutScene()
    {
        canRotate = false;
        RopeTrapCameraController scr = GetComponent<RopeTrapCameraController>();
        scr.enabled = true;
        RopeTrapCameraController.RopeTripCameraControl.Invoke();
    }
}
