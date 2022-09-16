using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    Rigidbody2D myRigidbody;
    Vector2 myVelocity;
    CapsuleCollider2D myCollider;
    [SerializeField] float mySpeed;
    [SerializeField] float myJump;
    [SerializeField] float jumpForce;
  
    [SerializeField] float myJumpHeight;
    [SerializeField] LayerMask groundMask;

    public bool onGround;
    public bool crouching;
    public bool jumping;
    public float startJump;
    RaycastHit2D groundHit;
    public bool canJump = true;
    public enum PlayerState { running, jumping, dashing }
    public PlayerState currentState;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    void Jump()
    {
       
        if (onGround)
        {
            jumping = true;
            startJump = transform.position.y;
            myVelocity.y = myJump;
            currentState = PlayerState.jumping;
        }
            
    }
    void Crouch()
    {
        canJump = true;
        if (onGround)
        {            
            StartCoroutine(Dash());
        }

    }
    IEnumerator Dash()
    {
        currentState = PlayerState.dashing;
        crouching = true;
        GetComponent<CapsuleCollider2D>().size = new Vector2(myCollider.size.x, 0.6f);
        GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.28f);
        myVelocity.x = 0.2f;
        yield return new WaitForSeconds(0.5f);
        GetUp();
    }
    void GetUp()
    {
        currentState = PlayerState.running;
        canJump = true;
        GetComponent<CapsuleCollider2D>().size = new Vector2(myCollider.size.x, 1.2f);
        GetComponent<CapsuleCollider2D>().offset = new Vector2(0, -0.08f);
        myVelocity.x = 0;
    }
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            if (canJump)
            {
                Jump();
            }
            crouching = false;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            if (!crouching)
            {
                Crouch();
            }
            
        }
        else
        {
            GetUp();
            crouching = false;
        }
        if (jumping)
        {
            if (transform.position.y > startJump + myJumpHeight)
            {
                Fall();
            }

        }
        else
        {
            if (onGround)
            {
                myVelocity.y = 0;
            }
            else
            {
                Fall();
            }
        }


        CheckGound();



    }
    void CheckGound()
    {
        groundHit = Physics2D.Raycast(myCollider.transform.position, Vector2.down, Mathf.Infinity, groundMask);
        float groundDistance = Mathf.Round((groundHit.distance + myCollider.offset.y) * 10) / 10;
        if (groundDistance <= myCollider.size.y / 2)
        {

            onGround = true;
            if (jumping) jumping = false;

        }
        else
        {
            onGround = false;

        }
    }
    void Fall()
    {
        canJump = false;
        myVelocity.y = Physics2D.gravity.y;
        
    }
    private void FixedUpdate()
    {
        myRigidbody.velocity = myVelocity;
    }


}
