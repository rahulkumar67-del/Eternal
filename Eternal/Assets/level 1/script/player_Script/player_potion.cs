using UnityEngine;

public class player_potion : MonoBehaviour
{
    [SerializeField] private float powertime;
    private float timeduration;
    private Vector3 initscale;
    private float initalspeed;
    private float initaljumpp;
    private player_controller_2d player_Controller_2D;
    private BoxCollider2D boxx;
    [SerializeField] private LayerMask moveablelayer;
    private Vector3 scalevector;

    private void Awake()
    {
        scalevector = new Vector3(transform.localScale.x + 1, transform.localScale.y + 1, transform.localScale.z);
        boxx = GetComponent<BoxCollider2D>();
        player_Controller_2D = GetComponent<player_controller_2d>();
        initalspeed =player_Controller_2D.speed;
        initaljumpp = player_Controller_2D.jumpPower;
        initscale = transform.localScale;
        Debug.Log("initalsccale of palyer" + initscale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Potion"))
        {
            transform.localScale = scalevector;
            timeduration = powertime;

            player_Controller_2D.speed = 1.5f * player_Controller_2D.speed;
            player_Controller_2D.jumpPower = 1.25f* player_Controller_2D.jumpPower;
           

        }

    }

    private void Update()
    {
        if (timeduration > 0)
        {
            RaycastHit2D raycastHit2 = Physics2D.BoxCast(boxx.bounds.center, boxx.bounds.size, 0, Vector2.down, 0.1f, moveablelayer);
            timeduration -= Time.deltaTime;
            if (timeduration <= 0 && !(raycastHit2.collider != null))
            {
               // transform.localScale = initscale;
                Debug.Log("transform scal after it retun to its original position0" + transform.localScale);
                timeduration = powertime;
                player_Controller_2D.speed = initalspeed;
                player_Controller_2D.jumpPower = initaljumpp;
            }
        }
    }
}
