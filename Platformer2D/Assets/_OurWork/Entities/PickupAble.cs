using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is mostly used to check if an object has this class
public class PickupAble : MonoBehaviour
{
    private Transform originalParent;

    void Start()
    {
        originalParent = this.transform.parent;
    }

    public void ReturnToParent()
    {
        this.transform.parent = originalParent;
    }
}
