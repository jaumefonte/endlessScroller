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
        myRigidbody.velocity = myVelocity;
    }

    private void Update()
    {
        transform.position += new Vector3(myVelocity.x, myVelocity.y, 0) * Time.deltaTime;
    }
}
