﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VHS;

public class WalkthroughTrigger : MonoBehaviour
{
    public MaterialType forwardChange;
    public MaterialType backwardChange;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER");
        Triggerable pickable = other.GetComponent<Triggerable>();
        if(pickable == null)
        {
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Trigger forwards");
            pickable.SetMaterial(forwardChange);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Trigger backwards");
            pickable.SetMaterial(backwardChange);
        }
    }
}
