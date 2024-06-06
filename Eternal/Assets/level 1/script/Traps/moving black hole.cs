using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 2f; // Speed of movement
    public float distance = 5f; // Distance to move
    private Vector3 startPos; // Starting position
    private Vector3 endPos; // Ending position
    private bool movingToEnd = true; // Whether the object is currently moving towards the end position

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.right * distance; // Move along the x-axis
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        while (true)
        {
            // Calculate the target position based on the current direction
            Vector3 targetPos = movingToEnd ? endPos : startPos;

            // Move the object towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            // If the object reaches the target position, change the direction
            if (transform.position == targetPos)
            {
                movingToEnd = !movingToEnd;
            }

            yield return null;
        }
    }
}
