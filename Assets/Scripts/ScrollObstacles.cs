using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObstacles : MonoBehaviour
{
    public Vector2 myVelocity;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = myVelocity;
    }
}
