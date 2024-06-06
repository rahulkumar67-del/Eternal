using UnityEngine;

public class player_potion : MonoBehaviour
{
    [SerializeField] private float powertime;
    private float timeduration;
    private Vector3 initscale;

    private void Awake()
    {
        initscale = transform.localScale;
        Debug.Log("initalsccale of palyer" + initscale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Potion"))
        {
            transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y + 1, transform.localScale.z);
            timeduration = powertime;
           

        }

    }

    private void Update()
    {
        if (timeduration > 0)
        {
            timeduration -= Time.deltaTime;
            if (timeduration <= 0)
            {
                transform.localScale = initscale;
                Debug.Log("transform scal after it retun to its original position0" + transform.localScale);
                timeduration = powertime;
            }
        }
    }
}
