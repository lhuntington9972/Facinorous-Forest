using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D playerRigidBody;
    
    public float movementSpeed;
    private float jumpDistance;
    private bool jumpReady;
    float moveHorizontal;
    float moveVertical;
    //public GameObject platformCheck; 
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();

        movementSpeed = 200f;
        jumpDistance = 300f;
        jumpReady = true;

        //sprite = GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {

        /*if(moveHorizontal > 0.1f)
        {
            sprite.flipX = false;
        } else if (moveHorizontal < -0.1f)
        {
            sprite.flipX = true;
        }*/

        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            playerRigidBody.velocity = new Vector2(moveHorizontal * movementSpeed * Time.deltaTime, 0f);
        } 

        if(jumpReady == true && moveVertical > 0.1f)
        {
            playerRigidBody.velocity = new Vector2(0f, moveVertical * jumpDistance * Time.deltaTime);
            jumpReady = false;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Platform")
        {
            jumpReady = true;
        }

    }
}
