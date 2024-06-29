using System;
using UnityEngine;

public class PlayerMovementRigidbody : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 3f;
    private Rigidbody _rigidbody;
    private bool groundedPlayer = true;
    Vector3 movementVector;

    private bool isCrouching;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        movementVector = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward;


        //Vector3 move = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        //Vector3 move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");

        //_rigidbody.velocity = new Vector3(move.x, _rigidbody.velocity.y, move.z) * moveSpeed;


        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {

        }

        ;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!isCrouching)
            {
                Crouch();

            }
            else
            {
                // ???
            }
            isCrouching = !isCrouching;
        }
    }

    void Crouch()
    {

    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + movementVector * moveSpeed * Time.fixedDeltaTime);
    }
}
