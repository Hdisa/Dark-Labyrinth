using System;
using UnityEngine;

public class RopeTrapCameraController : MonoBehaviour
{
    private bool isStarted;
    public static Action RopeTripCameraControl;
    
    private void OnEnable()
    {
        RopeTripCameraControl += ActivateRopeTrapCutScene;
    }
    
    private void OnDisable()
    {
        RopeTripCameraControl -= ActivateRopeTrapCutScene;
    }

    private void Update()
    {
        if (isStarted)
        {
            Quaternion newRotation = Quaternion.AngleAxis(90, Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .05f);
        }
    }
    
    void ActivateRopeTrapCutScene()
    {
        isStarted = true;
    }
}
