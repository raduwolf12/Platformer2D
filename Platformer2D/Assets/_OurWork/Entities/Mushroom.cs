using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    //Has a jump modifier for the player
    readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    public float jumpBoost = 8f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (this.enabled)
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null && !player.IsGrounded)
            {
                if (player.jumpState == PlayerController.JumpState.Grounded) //This is done to play jump sound
                {
                    player.jumpState = PlayerController.JumpState.PrepareToJump;
                }
                player.jump = false;
                player.velocity.y = jumpBoost * model.jumpModifier;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (this.enabled)
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null && !player.IsGrounded)
            {
                //Play bouncing sound or something
            }
        }
    }
}
