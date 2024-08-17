using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 vel = rb.velocity;
            vel.y = jumpSpeed;
            rb.velocity = vel;
        }
    }
}
