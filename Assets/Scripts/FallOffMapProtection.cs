using UnityEngine;

public class FallOffMapProtection : MonoBehaviour
{
    [SerializeField] private float minimumHeight;
    [SerializeField] private Vector3 resetPosition;
    [SerializeField] private Vector3 resetRotation;
    private CameraMovement cameraMovement;
    private Transform playerTransform;

    private void Update()
    {
        if(playerTransform == null)
        {
            playerTransform = FindObjectOfType<PlayerMovement>().transform;
            cameraMovement = FindObjectOfType<CameraMovement>();
        }

        if(playerTransform.position.y <= minimumHeight)
        {
            playerTransform.position = resetPosition;
            cameraMovement.SetCameraRotation(resetRotation);
        }
    }
}