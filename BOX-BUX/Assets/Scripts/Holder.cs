using System;
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

    // Update is called once per frame
    void Update()
    {
        releasing = false;
        if (held == null)
        {
            return;
        }
        var pos = transform.position;
        var ray = new Ray(new Vector3(pos.x + holdOffset.x, pos.y + holdOffset.y, pos.z + holdOffset.z), transform.forward);

        held.transform.position = ray.GetPoint(2);
        if (Input.GetKeyDown(KeyCode.E) && !becomingHeld)
        {
            Debug.Log("Releasing");
            held.rigid.isKinematic = false;
            held = null;
            releasing = true;
        }
        becomingHeld = false;
    }

    public void SetHeld(Pickable held)
    {
        becomingHeld = true;
        this.held = held;
        held.rigid.isKinematic = true;
    }
}
