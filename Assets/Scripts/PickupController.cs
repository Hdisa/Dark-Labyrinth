using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField] private float pickupDistance = 2.0f;
    [SerializeField] private Transform holdPosition;

    private PickupItem currentPickupItem;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentPickupItem == null)
                TryPickupItem();
            else 
                DropItem();
        }

        if (currentPickupItem == null) return;
        
        var boxTransform = currentPickupItem.transform;
        boxTransform.position = holdPosition.position;
        boxTransform.rotation = holdPosition.rotation;

    }

    private void TryPickupItem()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, pickupDistance))
        {
            PickupItem pickupItem = hit.collider.GetComponent<PickupItem>();
            if (pickupItem == null) return;
            currentPickupItem = pickupItem;
            currentPickupItem.SetPickedUp(true);
            currentPickupItem.transform.SetParent(holdPosition);
        }
    }

    private void DropItem()
    {
        if (currentPickupItem == null) return;
        currentPickupItem.SetPickedUp(false);
        currentPickupItem.transform.SetParent(null);
        currentPickupItem = null;
    }
}
