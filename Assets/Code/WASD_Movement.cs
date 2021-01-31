using UnityEngine;

public class WASD_Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float boundaryTop;
    [SerializeField]
    private float boundaryDown;
    [SerializeField]
    private float boundaryLeft;
    [SerializeField]
    private float boundaryRight;

    void Awake()
    {
        speed = 5f;
        boundaryTop = 5.5f;
        boundaryLeft = -5f;
        boundaryDown = -5.5f;
        boundaryRight = 5f;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W) && transform.position.y < boundaryTop)
        {
            moveY = +1f;
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > boundaryLeft)
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > boundaryDown)
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < boundaryRight)
        {
            moveX = +1f;
        }

        Debug.Log(transform.position);
        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }
}
