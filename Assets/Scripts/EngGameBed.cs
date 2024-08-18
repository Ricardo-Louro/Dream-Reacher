using UnityEngine;

public class EngGameBed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log("END GAME!");
        }
    }
}
