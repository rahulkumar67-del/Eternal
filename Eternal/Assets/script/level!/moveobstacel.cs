using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveobstacel : MonoBehaviour
{
    [SerializeField] float moveDistance = 1.0f; // Distance to move
    [SerializeField] float moveSpeed = 5.0f;    // Speed of movement
    private Vector3 startPosition;    // Starting position
    private Vector3 targetPosition;    // Target position

    private void Start()
    {
        startPosition = transform.position;                // Get the initial position
        targetPosition = startPosition + Vector3.right * moveDistance;  // Calculate the target position
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            targetPosition = startPosition + (targetPosition - startPosition) * -1;
        }
    }
}

