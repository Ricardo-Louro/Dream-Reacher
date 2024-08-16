using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform exit_position;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.transform.position = exit_position.position;
        }
    }
}
