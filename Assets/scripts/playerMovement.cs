using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    float shoes = 0;
    bool even = true;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            //animator.SetBool("isLanding", false);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetButtonDown("Shoes"))
        {
            if (even)
            {
                shoes += 1;
                even = false;
            }
            else if (!even)
            {
                shoes -= 1;
                even = true;
            }
        } else if (Input.GetButtonUp("Shoes"))
        {
            shoes = 0;
        }
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
        //animator.SetBool("isLanding", true);
    }

    private void FixedUpdate()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, shoes);
        jump = false;
        
    }
}
