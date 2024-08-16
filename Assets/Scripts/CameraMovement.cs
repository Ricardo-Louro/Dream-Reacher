using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [SerializeField] private float heightOffset;
    [SerializeField] private float mouseSensitivity;

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

            playerMovement.RotatePlayer();
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

        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.x -= Input.GetAxis("Mouse Y");
        rotation.y += Input.GetAxis("Mouse X");
        
        rotation.y = Mathf.Clamp(rotation.y, -90, 90);

        transform.rotation = Quaternion.Euler(rotation);
    }
}