using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Rigidbody2D body;
    private float horizontal = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (!body)
        {
            Debug.LogError("body of type RegitBody2D was not found during Start");
            return;
        }

        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
        float lookDirection = (body.velocity.x > 0) ? 1 : -1;
        transform.localScale = new Vector3(lookDirection, 1, 1);
    }
}
