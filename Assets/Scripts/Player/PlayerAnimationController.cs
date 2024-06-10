using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    PlayerMove playerMoveController;
    Animator ahimator;

    private static readonly int IsJumping = Animator.StringToHash("IsJumping");

    private void Awake()
    {
        playerMoveController = GetComponent<PlayerMove>();
        ahimator = GetComponent<Animator>();
    }

    private void Start()
    {
        playerMoveController.OnJump += Jump;
    }
    private void Jump()
    {
        ahimator.SetTrigger(IsJumping);
    }
}
