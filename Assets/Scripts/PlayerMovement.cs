using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 7f;
    private CharacterController characterController;
    private bool groundedPlayer;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    private float playerHeight;
    private bool isCrouching;
    private float crouchOffset;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerHeight = characterController.height;
        crouchOffset = playerHeight * 0.6f / 2;
    }
    
    void Update()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        characterController.Move(move * (Time.deltaTime * moveSpeed));


        
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpForce * 3.0f );
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!isCrouching)
            {
                Crouch();
                
                
            }
            else
            {
                UnCrouch();
            }
            isCrouching = !isCrouching;
        }
    }

    void Crouch()
    {
        characterController.height = playerHeight * 0.4f;
        characterController.Move(Vector3.down * (crouchOffset - 0.1f));
        
        
    }
    void UnCrouch()
    {
        transform.Translate(new Vector3(0, crouchOffset, 0));
        characterController.height = playerHeight;

    }
}
