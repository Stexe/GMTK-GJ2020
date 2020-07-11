﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class Trigger : MonoBehaviour
{
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
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Trigger backwards");
        }
    }
}
