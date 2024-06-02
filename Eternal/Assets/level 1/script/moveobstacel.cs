using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class moveobstacel : MonoBehaviour
{
    [SerializeField] private Transform positionA;
    [SerializeField] private Transform positionB;
    [SerializeField] private float Speed;
    private Vector2 targetPosition;



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


        transform.position = Vector2.MoveTowards(transform.position
            , targetPosition, Speed * Time.deltaTime);
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        collision.transform.SetParent(this.transform);
    //    }


    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        collision.transform.SetParent(null);
    //    }


    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(positionA.position, positionB.position);
    }

}