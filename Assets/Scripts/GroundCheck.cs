using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
            playerMovement.grounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
            playerMovement.grounded = false;
    }
}
