using UnityEngine;

public class EndGameBed : MonoBehaviour
{
    private StartAndEndGameTransition transition;

    private void Start()
    {
        transition = FindObjectOfType<StartAndEndGameTransition>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            transition.ActivateEndGame();
        }
    }
}
