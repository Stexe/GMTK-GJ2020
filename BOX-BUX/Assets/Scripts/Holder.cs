﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using VHS;

public class Holder : MonoBehaviour
{
    public Pickable held;
    public bool releasing;
    private bool becomingHeld;
    public Vector3 holdOffset;
    public static EventTriggerable onHeld = new EventTriggerable();
    public static EventTriggerable onRelease = new EventTriggerable();

    void FixedUpdate()
    {
        if (held == null)
        {
            return;
        }
        var pos = transform.position;
        var ray = new Ray(new Vector3(pos.x + holdOffset.x, pos.y + holdOffset.y, pos.z + holdOffset.z), transform.forward);

        held.GetComponent<Rigidbody>().position = ray.GetPoint(2);
    }

    private void Update()
    {
        releasing = false;
        if (held == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E) && !becomingHeld)
        {
            Debug.Log("Releasing");
            onRelease.Invoke(held);
            held.GetComponent<Rigidbody>().isKinematic = false;
            held = null;
            releasing = true;
        }
        becomingHeld = false;
    }

    public void SetHeld(Pickable held)
    {
        if (releasing)
        {
            return;
        }
        Debug.Log("Holding");
        held.rigid.isKinematic = true;
        becomingHeld = true;
        this.held = held;
        held.GetComponent<Rigidbody>().isKinematic = true;
        onHeld.Invoke(held);
    }
}
