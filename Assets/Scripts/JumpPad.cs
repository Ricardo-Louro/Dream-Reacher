using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            audioSource.Play();

            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 vel = rb.velocity;
            vel.y = jumpSpeed;
            rb.velocity = vel;

            animator.SetTrigger("Bounce");
        }
    }
}
