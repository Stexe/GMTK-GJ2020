using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    [Serializable]
    public class Order
    {
        public ColorType colorGoal;
        public MaterialType materialGoal;
        public ShapeType shapeGoal;
    }

    public List<Order> orders;
    private Order currentOrder;
    private bool wonPrinted = false;

    private void Update()
    {
        if (currentOrder == null)
        {
            if (orders.Count > 0)
            {
                currentOrder = orders[0];
                orders.RemoveAt(0);
                Debug.Log("GOAL: " + currentOrder.materialGoal + ", " + currentOrder.colorGoal + ", " + currentOrder.shapeGoal);
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
        Triggerable triggerable = other.GetComponent<Triggerable>();
        if (triggerable == null)
        {
            return;
        }
        if (triggerable.GetShapeType() == currentOrder.shapeGoal
            && triggerable.GetMaterialType() == currentOrder.materialGoal
            && triggerable.GetColorType() == currentOrder.colorGoal)
        {
            Debug.Log("GIANT ENEMY GOAL GOT");
            Destroy(triggerable.asPickable().gameObject);
            currentOrder = null;
        }
        else
        {
            Debug.Log("TRY FLIPPING OVER FOR TONS OF DAMAGE");
        }
    }
}
