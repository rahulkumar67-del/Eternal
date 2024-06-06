using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

 

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        initScale = transform.localScale;
    }
    private void OnDisable()
    {
        anim.SetBool("move", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (transform.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("move", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("move", true);

        //Make enemy face direction
        transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //Move in that direction
        transform.position = new Vector3(transform.position.x + Time.deltaTime * _direction * speed,
            transform.position.y, transform.position.z);
    }
}