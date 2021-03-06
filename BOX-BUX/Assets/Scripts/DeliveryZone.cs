﻿using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeliveryZone : MonoBehaviour
{
    public static EventTriggerable onDelivered = new EventTriggerable();
    public static EventOrder onNewOrder = new EventOrder();

    public List<Order> orders;
    private Order currentOrder;
    private bool wonPrinted = false;
    private HudText score;
    
    private void Start()
    {
        score = FindObjectOfType<HudText>();
    }

    private void Update()
    {
        if (currentOrder == null)
        {
            if (orders.Count > 0)
            {
                currentOrder = orders[0];
                orders.RemoveAt(0);
                onNewOrder.Invoke(currentOrder);
                Debug.Log("GOAL: " + currentOrder.materialGoal + ", " + currentOrder.colorGoal + ", " + currentOrder.shapeGoal + ", " + currentOrder.sizeGoal);
            }
            else if (!wonPrinted)
            {
                wonPrinted = true;
                Debug.Log("YOU ARE WIN");
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Triggerable box = other.GetComponent<Triggerable>();
        if (box == null)
        {
            return;
        }
        if (box.GetShapeType() == currentOrder.shapeGoal
            && box.GetMaterialType() == currentOrder.materialGoal
            && box.GetColorType() == currentOrder.colorGoal
            && box.GetSizeType() == currentOrder.sizeGoal)
        {
            Deliver(box.asPickable());
        }
        else
        {
            Debug.Log("TRY FLIPPING OVER FOR MASSIVE DAMAGE");
        }
    }

    private void Deliver(Pickable box)
    {
        Debug.Log("GIANT ENEMY GOAL GOT");
        onDelivered.Invoke(box);
        Destroy(box.gameObject);
        currentOrder = null;
    }
}
