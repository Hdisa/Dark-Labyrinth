using UnityEngine;

public class RockDoor : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] Transform player;
    private Vector3 rotor = new Vector3(1f,0f,0);
    bool da = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
    }
    


    void Update()
    {
        
            float timer = 0;
            timer += Time.deltaTime;
            rb.velocity = new Vector3(Mathf.Min(-5f, -1f*timer),0,0f);
        
    }
    void FixedUpdate()
    {
        
            //Vector3 newPosition = Vector3.Lerp(transform.position, player.position, 0.5f * Time.deltaTime);
            //rb.MovePosition(newPosition);
        
    }
}
