using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller_3D : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 500f;

    [Header("Ground Check Settings")]
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] Vector3 groundCheckOffset;
    [SerializeField] LayerMask groundLayer;

    bool isGrounded;

    float ySpeed;
    Quaternion targetRotation;

    private Camera_Controller cameraController;
    private Animator animator;
    private CharacterController characterController;
    private void Awake()
    {
        cameraController = Camera.main.GetComponent<Camera_Controller>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float velocityX = Input.GetAxis("Horizontal");
        float velocityY = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Clamp01(Mathf.Abs(velocityX) + Mathf.Abs(velocityY));

        var moveInput = (new Vector3(velocityX, 0, velocityY)).normalized;

        var moveDir = cameraController.PlanarRotation * moveInput;

        velocityY = Mathf.Clamp(velocityY, -2f, 2f);
        velocityX = Mathf.Clamp(velocityX, -2f, 2f);


        GroundCheck();
        if (isGrounded)
        {
            ySpeed = -0.5f;
        }
        else
        {
            ySpeed += Physics.gravity.y * Time.deltaTime;
        }

        var velocity = moveDir * moveSpeed;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (moveAmount > 0)
        {
            targetRotation = Quaternion.LookRotation(moveDir);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
            rotationSpeed * Time.deltaTime);

        animator.SetFloat("VelocityX", velocityX, 0.2f, Time.deltaTime);
        animator.SetFloat("VelocityZ", velocityY, 0.2f, Time.deltaTime);
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundLayer);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);
    }
}
