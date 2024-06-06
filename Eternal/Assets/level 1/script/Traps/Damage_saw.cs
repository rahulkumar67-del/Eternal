using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Damage_saw : MonoBehaviour
{
    [SerializeField] private float Damage;
    [SerializeField] private float Speed;
    private float leftEdge;
     private float rightEdge;

    [SerializeField] private float movementdisatance;
    private bool movingleft;

    private void Awake()
    {
        leftEdge = transform.position.x - movementdisatance;
        rightEdge = transform.position.x + movementdisatance;
    }
    private void Update()
    {
        if (movingleft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector2(transform.position.x- Speed*Time.deltaTime,  transform.position.y);
            }
            else
            {
                movingleft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector2(transform.position.x +Speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                movingleft = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(Damage);
        }
    }
}
