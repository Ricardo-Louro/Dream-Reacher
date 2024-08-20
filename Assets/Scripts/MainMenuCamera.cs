using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCamera : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] private Transform islandTransform;
    private float angle = 0;
    [SerializeField] private float angleIncrements;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void Update()
    {
        angle += angleIncrements * Time.deltaTime;

        cameraTransform.position = new Vector3(Mathf.Cos(angle),
                                               islandTransform.position.y + .2f,
                                               Mathf.Sin(angle));

        Vector3 lookPos = islandTransform.position;
        lookPos.y += .2f;
        cameraTransform.LookAt(lookPos);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
