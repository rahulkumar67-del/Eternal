using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] Transform followTarget;

    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float distance = 5;

    [SerializeField] float minVerticalAngle = -45;
    [SerializeField] float maxVerticalAngle = 45;

    [SerializeField] Vector2 framingOffset;

    [SerializeField] bool invertX;
    [SerializeField] bool invertY;


    float rotationX;
    float rotationY;

    float invertXVal;
    float invertYVal;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;

        rotationX += Input.GetAxis("Mouse Y") * invertYVal * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);

        rotationY += Input.GetAxis("Mouse X") * invertXVal * rotationSpeed;

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

        var focusPostion = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);
        Debug.Log("Player position: " + followTarget.position);
        Debug.Log("Camera position: " + transform.position);


        transform.position = focusPostion - targetRotation* new Vector3(0, 0, distance);
        transform.rotation = targetRotation;
    }

    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);
}
