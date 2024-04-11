using UnityEngine;



public class CameraController_2d : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.3f; // Adjust for desired smoothness
    [SerializeField] private float verticalLimit = -5.0f; // Maximum depth the camera follows (negative for downward)

    private Vector3 velocity;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z); // Maintain camera's Z position

        // Clamp target position within vertical limit
        targetPosition.y = Mathf.Clamp(targetPosition.y, verticalLimit, Mathf.Infinity);

        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        transform.position = newPosition;
    }
}
