using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpringJump : MonoBehaviour
{
    [SerializeField] private float springForce = 13f;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.up, transform.localScale.y);

        if (hits.Any(hit => hit.collider.gameObject.name == "Player"))
        {
            Rigidbody2D body = collider2D.gameObject.GetComponent<Rigidbody2D>();
            body.velocity = new Vector2(body.velocity.x, springForce);
        }
    }
}
