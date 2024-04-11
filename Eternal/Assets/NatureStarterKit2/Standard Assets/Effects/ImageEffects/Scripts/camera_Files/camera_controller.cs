using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float distance = 100f;
    public Vector3 postionoffset;

    void Update()
    {
        Vector3 targetPosition = player.position - player.forward * distance +postionoffset;
        transform.position = targetPosition;

        transform.LookAt(player);
        
    }
}
