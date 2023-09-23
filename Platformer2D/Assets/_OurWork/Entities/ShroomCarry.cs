using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomCarry : MonoBehaviour
{
    private bool CarryingShroom = false;
    private Transform carriedMushroom; // Track the currently carried mushroom
    public GameObject MushroomParent; // Object which is parent to all shrooms
    private Transform[] mushrooms;
    private PlayerController playerController;
    private float pickupRange = 3f;

    void Start()
    {
        // Get a list of all shrooms
        mushrooms = MushroomParent.GetComponentsInChildren<Transform>();
        // ^ Should maybe sort for faster iteration
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

    }

    void Update()
    {   

  
        if( playerController .IsGrounded)
        {
            // Check if there is a mushroom carried by the player
            if (CarryingShroom && Input.GetKeyDown(KeyCode.R))
            {
                DropMushroom();
            }
        }
       

        Transform nearestShroom = null;
        float nearestDistance = pickupRange;

        foreach (Transform shroom in mushrooms)
        {
            // Calculate the distance between the player and the current shroom
            float distance = Vector3.Distance(transform.position, shroom.position);

            // Check if the current shroom is within pickup range and closer than previous ones
            if (distance < pickupRange && distance < nearestDistance)
            {
                nearestShroom = shroom;
                nearestDistance = distance;
            }
        }

        // Visualize the pickup interaction (e.g., show a prompt on the UI)
        if (nearestShroom != null)
        {
            // Show the player that the pickup interaction is available (e.g., display a message on the screen)
            Debug.Log("Press 'E' to pick up the mushroom");
            
            // If 'E' key is pressed, pick up the nearest shroom
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpMushroom(nearestShroom);
            }
        }
    }

    void PickUpMushroom(Transform shroomToPickUp)
    {
        // Make sure we're not already carrying a mushroom
        if (!CarryingShroom)
        {
            // Make the shroom a child of the player
            shroomToPickUp.parent = transform;

            // Disable the shroom script (you should replace "Mushroom" with your actual script name)
            Mushroom shroomScript = shroomToPickUp.GetComponent<Mushroom>();
            Mushroom shroomJumpScript = shroomToPickUp.GetComponentInChildren<Mushroom>(true); // Use GetComponentInChildren

            if (shroomScript != null)
            {
                shroomJumpScript.enabled = false;
                shroomScript.enable = false;
                Debug.Log("Mushroom script disabled.");
            }
            else
            {
                Debug.LogWarning("Mushroom script not found on the picked-up mushroom.");
            }


            // Set CarryingShroom to true
            CarryingShroom = true;

            // Track the currently carried mushroom
            carriedMushroom = shroomToPickUp;

            // Handle any other logic related to picking up a mushroom
        }
    }

    void DropMushroom()
    {
        if (CarryingShroom && carriedMushroom != null)
        {
            // Remove the mushroom from the player's transform
            carriedMushroom.parent = null;

            // Re-enable the mushroom script (you should replace "Mushroom" with your actual script name)
            Mushroom shroomScript = carriedMushroom.GetComponent<Mushroom>();
            
            if (shroomScript != null)
            {
                shroomScript.enabled = true;
                shroomScript.enable = true;

            }
            // carriedMushroom.transform.parent = null; // Unparent from the player
            Rigidbody2D shroomRigidbody2D = carriedMushroom.GetComponent<Rigidbody2D>();
            // shroomRigidbody2D.isKinematic = false;
            shroomRigidbody2D.gravityScale = 1f;

            // Reset variables
            CarryingShroom = false;
            carriedMushroom = null;

         }
    }
}
