using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D playerRigidBody;
    
    private float movementSpeed;
    private float jumpDistance;
    private bool isJumping;
    float moveHorizontal;
    float moveVertical;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();

        movementSpeed = 3;
        jumpDistance = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {

        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            playerRigidBody.AddForce(new Vector2(moveHorizontal * movementSpeed, 0f), ForceMode2D.Impulse);
        } 

        if(!isJumping && moveVertical > 0.1f)
        {
            playerRigidBody.AddForce(new Vector2(0f, moveVertical * jumpDistance));
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {

    }
}
