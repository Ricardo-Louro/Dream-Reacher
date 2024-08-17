using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;

    public float jumpCooldown;
    public float airMultiplier;

    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;


    [Header("Ground Check")]

    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);

        MyInput();
        SpeedControl();

        if(grounded) rb.drag = groundDrag;
        else rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


   private void MyInput()
   {
       horizontalInput = Input.GetAxis("Horizontal");
       verticalInput = Input.GetAxis("Vertical");

       if(Input.GetKey(jumpKey) && readyToJump && grounded)
       {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
       }
   }

   private void MovePlayer()
   {
        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
   }

   private void SpeedControl()
   {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatvel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatvel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
   }

   private void Jump()
   {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
   }

   private void ResetJump()
   {
        readyToJump = true;
   }

   public void RotatePlayer(float value)
   {
        Vector3 rotation = Vector3.zero;
        rotation.y = value;
        transform.rotation = Quaternion.Euler(rotation);
   }
}
