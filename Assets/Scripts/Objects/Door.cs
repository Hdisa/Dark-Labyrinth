using UnityEngine;
using System.Collections;
using System.Linq;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform doorTransform;
    [SerializeField] private Quaternion openRotation;
    [SerializeField] private float openSpeed = 2f;
    [SerializeField] private PressurePlate[] plates;

    private Quaternion closedPosition;
    private bool isOpen;

    void Start()
    {
        closedPosition = doorTransform.rotation;
    }

    private void Update()
    {
        if (plates.All(plate => plate.onPlate))
            OpenDoor();
    }

    private void OpenDoor()
    {
        if (!isOpen)
            StartCoroutine(OpenDoorCoroutine());
    }

    private IEnumerator OpenDoorCoroutine()
    {
        isOpen = true;
        float elapsedTime = 0;

        while (elapsedTime < openSpeed)
        {
            doorTransform.rotation = Quaternion.Lerp(closedPosition, openRotation, elapsedTime / openSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        doorTransform.rotation = openRotation;
    }
}
