using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomCarry : MonoBehaviour
{
    private bool CarryingShroom = false;
    public GameObject MushroomParent; //Object which is parent to all shrooms
    private Transform[] mushrooms;
    private float pickupRange = 5f;
    
    void Start()
    {
        //Get a list of all shrooms
        mushrooms = MushroomParent.GetComponentsInChildren<Transform>();
        //^Should maybe sort for faster iteration
    }

    void Update()
    {
        foreach (Transform shroom in mushrooms) { //Maybe change this to use a collider for better efficiency
            if (Vector3.Distance(this.transform.position, shroom.position) < pickupRange)
            {
                //Show the player that the pickup interaction is available
            }
        }

        //If within certain distance, pickup a shroom
        if(Input.GetKeyDown(KeyCode.E)) //This should be visualized in someway
        {

        }


        //On press key, take shroom
            //Make shroom a child of player
            //Disable shroom script
    }
}
