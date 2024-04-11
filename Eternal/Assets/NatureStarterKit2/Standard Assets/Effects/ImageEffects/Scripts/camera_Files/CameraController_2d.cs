using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float verticalLimitTop;
    public float verticalLimitBottom;

    private Vector3 offset;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned to camera controller!");
            return;
        }

        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 targetPosition = target.position + offset;
        targetPosition.x = transform.position.x;

        if (target.position.y > verticalLimitTop || target.position.y < verticalLimitBottom)
        {
            targetPosition.y = transform.position.y;
        }

        transform.position = targetPosition;
    }
}
