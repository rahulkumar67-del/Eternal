using System.Collections;
using UnityEngine;

public class moveobstacel : MonoBehaviour
{
    [SerializeField] private Transform positionA;
    [SerializeField] private Transform positionB;
    [SerializeField] private float Speed;
    private Vector2 targetPosition;
    private Transform playerTransform;
    private Vector3 playerOriginalScale;

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
       // playerTransform = collision.transform;
       // // localscale = orignallocalscale/platformlocalscale
       // playerOriginalScale = playerTransform.localScale;

       // Debug.Log("playerOriginalScale" + playerOriginalScale);
       // if (collision.CompareTag("Player"))
       // {
          
       //     playerTransform.SetParent(transform, true);
       //     Vector3 adjustedScale = new Vector3(
       //    playerOriginalScale.x / transform.localScale.x,
       //    playerOriginalScale.y / transform.localScale.y,
       //    playerOriginalScale.z / transform.localScale.z
       //);

       //     // Apply the adjusted scale to the player
       //     //playerTransform.localScale = adjustedScale;

       //     Debug.Log("playerOriginalafter: " + adjustedScale);
       // }


        collision.transform.SetParent(this.transform);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            //collision.transform.localScale = playerOriginalScale;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(positionA.position, positionB.position);
    }
}