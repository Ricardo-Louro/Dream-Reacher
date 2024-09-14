using UnityEngine;

public class FakeFloor : MonoBehaviour
{

    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        
        if(playerMovement != null)
        {
            playerMovement.transform.position = position;
            playerMovement.transform.eulerAngles = rotation;
        } 
    }
}
