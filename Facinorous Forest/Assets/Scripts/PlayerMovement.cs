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

    // Start is called before the first frame update
    void Start()
    {
        speed = speedNum;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }

    // Move Character
    private void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        
    }
}
