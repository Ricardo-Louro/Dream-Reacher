using UnityEngine;

public class FallOffMapProtection : MonoBehaviour
{
    [SerializeField] private float minimumHeight;
    [SerializeField] private Vector3 resetPosition;
    private Transform playerTransform;

    private void Update()
    {
        if(transform == null)
        {
            playerTransform = FindObjectOfType<PlayerMovement>().transform;
        }

        if(transform.position.y >= minimumHeight)
        {
            playerTransform.position = resetPosition;
        }
    }
}