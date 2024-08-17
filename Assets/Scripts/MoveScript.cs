using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [Header("Movement Object")]
    private Axis axis;
    [SerializeField] private float speed;
    private float currentSpeed;
    [SerializeField] private float MaxVal;
    [SerializeField] private float MinVal;

    private bool playerTouch;

    Rigidbody rb;


    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        currentSpeed = speed;
    }

    private void Update()
    {

        if(axis == Axis.x)
        {
            if(transform.position.x > MaxVal) currentSpeed = -speed;
            
            if(transform.position.x < MinVal) currentSpeed = speed;    
        }
        else if(axis == Axis.y)
        {
            if(transform.position.y > MaxVal) currentSpeed = -speed;
            
            if(transform.position.y < MinVal) currentSpeed = speed;     
        }
        else
        {
            if(transform.position.z > MaxVal) currentSpeed = -speed;
            
            if(transform.position.z < MinVal) currentSpeed = speed; 
        }
               
    }
    private void FixedUpdate()
    {
        if(axis == Axis.x)
        { 
            Vector3 vel = rb.velocity;
            vel.x = currentSpeed;
            rb.velocity = vel;
        }
        else if(axis == Axis.y)
        { 
            Vector3 vel = rb.velocity;
            vel.y = currentSpeed;
            rb.velocity = vel;
        }
        else
        { 
            Vector3 vel = rb.velocity;
            vel.z = currentSpeed;
            rb.velocity = vel;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
       if(other.GetComponent<PlayerMovement>() != null)
       {
            playerTouch = true;
       }
 
    }
    private void OnTriggerExit(Collider other)
    {
       if(other.GetComponent<PlayerMovement>() != null)
       {
            playerTouch = false;
       }
    }
   
}

public enum Axis
{
    x, 
    y,
    z
}
