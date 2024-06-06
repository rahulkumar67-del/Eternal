using UnityEngine;

public class PowerInc : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          
            Destroy(gameObject);

        }

    }

  
}
