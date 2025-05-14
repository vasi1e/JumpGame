using System.Linq;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D body;
    private bool isJumping = false;
    private bool isOnGround = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isJumping)
        {
            isJumping = Input.GetButtonDown("Jump") && isOnGround;
        }
    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            if (!body)
            {
                Debug.LogError("body of type RegitBody2D was not found during Start");
                return;
            }

            body.velocity = new Vector2(body.velocity.x, jumpForce);
            isJumping = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = determineOnGround();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = determineOnGround();
    }

    bool determineOnGround()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, transform.localScale.y);
        return hits.Any(hit => hit.collider.gameObject.name != "Player" && !hit.collider.isTrigger);
    }
}
