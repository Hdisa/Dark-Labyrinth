using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private ObjectGrabable grabable;
    private Camera cam;
    private float distance = 15f;
    private GameObject currentThing;
    private Rigidbody currentThingRB;
    private Transform grabPointTransform;
    private bool canPickUp = true;
    [SerializeField] private LayerMask kost;
    [SerializeField] private LayerMask pickableMask;
    
    void Start()
    {
        cam = Camera.main;
        grabPointTransform = transform;
    }
    
    void Update()
    {
        if (canPickUp)
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                PickUp();
            }
        }
        else
        {
            //currentThingRB.AddForce((transform.position - currentThing.transform.position) * 200f * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Drop();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentThingRB.angularVelocity = Vector3.zero;
                currentThingRB.velocity = Vector3.zero;
                currentThing.transform.localEulerAngles = new Vector3(-cam.transform.localEulerAngles.x, 0, 0);
            }
        }
    }
    
    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance, pickableMask)) {
            if (hit.transform.TryGetComponent(out ObjectGrabable grababled)) 
            {
                grabable = grababled;
                grabable.Grab(grabPointTransform);



                currentThing = hit.transform.gameObject;
                currentThing.layer = 8;
                //currentThing.GetComponent<Rigidbody>().isKinematic = true;
                //currentThing.transform.parent = transform;
                currentThing.transform.localPosition = transform.position;
                currentThingRB = currentThing.gameObject.GetComponent<Rigidbody>();
                //currentThingRB.useGravity = false;
                currentThingRB.velocity = Vector3.zero;
                currentThing.transform.localEulerAngles = Vector3.zero;
                canPickUp = false;

            }
        }
    }

    void Drop()
    {
        //currentThing.transform.parent = null;
        grabable.Drop();
       //currentThing.GetComponent<Rigidbody>().isKinematic = false;
        canPickUp = true;
        //currentThingRB.useGravity = true;
        currentThing.layer = 7;
        currentThing = null;
    }
}
