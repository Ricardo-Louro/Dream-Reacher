using UnityEngine;

public class FakePortalRotation : MonoBehaviour
{
    [SerializeField] private Transform portalInside;
    [SerializeField] private float rotationIncrement;

    private void Update()
    {
        Vector3 rot = portalInside.transform.rotation.eulerAngles;
        rot.z += rotationIncrement;
        portalInside.transform.rotation = Quaternion.Euler(rot);
    }
}
