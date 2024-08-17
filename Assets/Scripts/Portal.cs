using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform exit_position;
    [SerializeField] private Vector3 exit_rotation;
    private CameraMovement cameraMovement;

    [SerializeField] private Transform portalInside;
    [SerializeField] private float rotationIncrement;


    private void Start()
    {
        cameraMovement = FindObjectOfType<CameraMovement>();
    }

    private void Update()
    {
        Vector3 rot = portalInside.transform.rotation.eulerAngles;
        rot.z += rotationIncrement;
        portalInside.transform.rotation = Quaternion.Euler(rot);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.transform.position = exit_position.position;
            cameraMovement.SetCameraRotation(exit_rotation);
        }

    }
}
