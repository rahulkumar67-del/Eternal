using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    Transform nextRoom;

    private bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isOpen)
        {
            OpenDoor(collision.transform);
        }
    }

    private void OpenDoor(Transform playerTransform)
    {
        isOpen = true;
        transform.position = nextRoom.position;
        playerTransform.position = nextRoom.position;
    }
}
