using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [SerializeField] private float heightOffset;
    [SerializeField] private float mouseSensitivity;

    private Vector3 rotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rotation = transform.rotation.eulerAngles;
    }
    // Update is called once per frame
    private void Update()
    {
        if(playerMovement == null)
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }

        if(playerMovement != null)
        {
            SetCameraPosition();
            RotateCamera();

            playerMovement.RotatePlayer(transform.rotation.eulerAngles.y);
        }
    }

    private void SetCameraPosition()
    {
        Vector3 pos = playerMovement.transform.position;
        pos.y += heightOffset;
        transform.position = pos;
    }

    private void RotateCamera()
    {
        rotation.x -= Input.GetAxis("Mouse Y");
        rotation.y += Input.GetAxis("Mouse X");
        
        rotation.x = Mathf.Clamp(rotation.x, -80, 80);

        transform.rotation = Quaternion.Euler(rotation);
    }
}