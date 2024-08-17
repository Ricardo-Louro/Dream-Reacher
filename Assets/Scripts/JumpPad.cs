using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 vel = rb.velocity;
            vel.y = jumpSpeed;
            rb.velocity = vel;

            animator.SetTrigger("Bounce");
        }
    }
}
