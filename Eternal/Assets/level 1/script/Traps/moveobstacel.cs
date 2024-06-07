using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField] private Transform positionA;
    [SerializeField] private Transform positionB;
    [SerializeField] private float Speed;
    private Vector2 targetPosition;

    private Vector3 playerOriginalScale;
    private Transform playerTransform;

    private void Awake()
    {
        targetPosition = positionB.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, positionA.position) < 0.1f)
        {
            targetPosition = positionB.position;
        }

        if (Vector2.Distance(transform.position, positionB.position) < 0.1f)
        {
            targetPosition = positionA.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerTransform = collision.transform;
            playerOriginalScale = playerTransform.lossyScale;

            Vector3 parentWorldScale = transform.lossyScale;
            Vector3 newLocalScale = new Vector3(
                playerOriginalScale.x / parentWorldScale.x,
                playerOriginalScale.y / parentWorldScale.y,
                playerOriginalScale.z / parentWorldScale.z
            );

            playerTransform.SetParent(transform);
            playerTransform.localScale = newLocalScale;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            collision.transform.localScale = playerOriginalScale; // Restore the original scale
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(positionA.position, positionB.position);
    }
}
