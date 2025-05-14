using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject startingPoint;

    void Start()
    {
        transform.position = startingPoint.transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "End Mark")
        {
            transform.position = startingPoint.transform.position;
        }
    }
}
