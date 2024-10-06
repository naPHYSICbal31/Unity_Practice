using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator _animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
       horizontalMove =  Input.GetAxisRaw("Horizontal") * runSpeed;
        _animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
       if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            _animator.SetBool("isJumping", true);
        }
       if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
       else if(Input.GetButtonUp("Crouch"))
        {
           crouch= false;
        }

    }
    public void OnLanding()
    {
        _animator.SetBool("isJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        _animator.SetBool("isCrouching",isCrouching);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }
}
