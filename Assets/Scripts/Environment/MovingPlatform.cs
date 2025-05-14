using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Rigidbody2D body;
    private float horizontal = -1;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!body)
        {
            Debug.LogError("body of type RegitBody2D was not found during Start");
            return;
        }
        
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        horizontal *= -1;
    }
}
