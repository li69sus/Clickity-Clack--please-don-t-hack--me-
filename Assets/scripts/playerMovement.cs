using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
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
    //public CinemachineCamera cam1;
    //public CinemachineCamera cam2;

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
                //CameraManager.SwitchCamera(cam2);
            }
            else if (!even)
            {
                shoes -= 1;
                even = true;
                //CameraManager.SwitchCamera(cam1);
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
