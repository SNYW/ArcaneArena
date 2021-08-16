using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.aiming)
        {
            animator.SetFloat("moveVal", playerController.GetGamepad().leftStick.ReadValue().x);
        }
        else
        {
            if(playerController != null && playerController.GetGamepad() != null)
            {
                if (playerController.GetGamepad().leftStick.ReadValue().x != 0 || playerController.aiming)
                {
                    animator.SetFloat("moveVal", playerController.GetGamepad().leftStick.ReadValue().x);
                }
                else
                {
                    animator.SetFloat("moveVal", GetComponent<Rigidbody>().velocity.x);
                }
            }
        }
        animator.SetBool("Grounded", playerController.IsGrounded());
        animator.SetBool("Charging", playerController.charging);
        animator.SetBool("Firing", playerController.aiming);

    }
}
