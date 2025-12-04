using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 10, 0);

    private void FixedUpdate()
    {
        transform.position = playerTransform.position + cameraOffset;
    }
}
