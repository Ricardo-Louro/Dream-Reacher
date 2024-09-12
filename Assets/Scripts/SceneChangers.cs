using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangers : MonoBehaviour
{
    [SerializeField] private int sceneBuildIndex;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}