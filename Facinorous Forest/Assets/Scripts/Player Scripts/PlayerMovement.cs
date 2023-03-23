using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

public CharacterController2D controller;

float speedNum = 20f;
public float speed;
float horizontalMove = 0f;
bool jump = false;
bool walk = false;
bool sprint = false;

private bool canDash = true;
private bool isDashing;
private float dashingPower = 24f;
private float dashingTime = 0.2f;
private float dashingCooldown = 0.5f;

[SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = speedNum;
    }

    // Update is called once per frame
    void Update()
    {

        if (isDashing)
        {
            return;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if(walk == true && sprint == false)
        {
            speed = speedNum / 2f;
        } else if(sprint == true && walk == false)
        {
            speed = speedNum * 2f;
        } else if (walk == false && sprint == false)
        {
            speed = speedNum;
        }

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Walk"))
        {
            walk = true;
        } else if (Input.GetButtonUp("Walk"))
        {
            walk = false;
        }

        if (Input.GetButtonDown("Sprint"))
        {
            sprint = true;
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            sprint = false;
        }

        if(Input.GetKeyDown(KeyCode.F) && canDash == true)
        {
            StartCoroutine(Dash());
        }

    }

    // Move Character
    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        
    }

    private IEnumerator Dash()
    {
        canDash = false; 
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    } 

}
