using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomCarry : MonoBehaviour
{
    public GameObject PickupKeyVisual;

    private bool CanPickup = false;
    private GameObject nearbyShroom = null;
    private GameObject CarriedShroom = null;
    private bool IsCarrying = false;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PickupAble>() != null) {
            SetPickupAble(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == nearbyShroom)
        {
            nearbyShroom = null;
            CanPickup=false;
            PickupKeyVisual.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsCarrying)
            {
                IsCarrying = false;
                CarriedShroom.GetComponent<PickupAble>().ReturnToParent();
                CarriedShroom.GetComponentInChildren<Mushroom>().enabled = true;
                CarriedShroom.GetComponent<Rigidbody2D>().isKinematic = false;
                
                SetPickupAble(CarriedShroom);
            }
            else if (CanPickup)
            {
                IsCarrying = true;
                nearbyShroom.transform.position = this.transform.position;
                nearbyShroom.transform.parent = this.transform;
                CarriedShroom = nearbyShroom;
                CarriedShroom.GetComponentInChildren<Mushroom>().enabled = false;
                CarriedShroom.GetComponent<Rigidbody2D>().isKinematic = true;
                PickupKeyVisual.SetActive(false);
            }
        }
    }

    private void SetPickupAble(GameObject mushroom)
    {
        nearbyShroom = mushroom;
        CanPickup = true;
        if (!IsCarrying)
        {
            PickupKeyVisual.SetActive(true);
        }
    }
}
