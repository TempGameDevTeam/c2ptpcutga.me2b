using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class Char_Movement : MonoBehaviour {
	// testing variables
	public float speedcount=0f;
	
	
	//setting default movement speed
	public float verticalSpeed = 0.1f;
	
	//setting hoe high thre charachter will jump
	public float jumpForce = 20f;
	private bool isGrounded = true;
    private bool isJumping = false;

 
	public bool isRight;
	public bool isLeft;
	
	//this will detect if it hits  ceiling or ground 
	//if hit ceiling  the jump will stop
	void OnCollisionEnter2D(Collision2D other)
	{
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    

		if (other.gameObject.tag == "ceiling") {
			isGrounded=false;
		}
		
	}
	
	// this will slow the  jump  so that it would menimise the impact on the ceiling if any
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "jumpAccLimit") {
			isGrounded = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

        //check to see if char is grounded
        //if the char is not moving veritcally, then he is not jumping or falling from a jump
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            isGrounded = true;
            isJumping = false;
        }

//      ================ BASIC MOVEMENTS ==============
        //moving right
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right"))
        {
                speedcount = verticalSpeed * 1.0001f;
                transform.Translate(verticalSpeed * 1.1f, 0, 0);
        }

        //moving left
        if (Input.GetKey(KeyCode.A) || Input.GetKey("left"))
        {
                speedcount = verticalSpeed * 1.0001f;
                transform.Translate(-verticalSpeed * 1.1f, 0, 0); 
        }
		
		//calling jump method
        if ((Input.GetKey(KeyCode.Space) && isGrounded || Input.GetKey("w") && isGrounded))
        { 
            Jump();
        }	
		
	}
	
	void Jump()
	{   
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Force);
        isJumping = true;
        isGrounded = false;
	}
}
