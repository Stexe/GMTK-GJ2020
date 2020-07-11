using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    public MaterialType materialGoal;
    public ShapeType shapeGoal;

    private void Start()
    {
        Debug.Log("GOAL: " + materialGoal + ", " + shapeGoal);
    }

    public void OnTriggerEnter(Collider other)
    {
        Triggerable triggerable = other.GetComponent<Triggerable>();
        if(triggerable == null)
        {
            return;
        }
        if(triggerable.GetShapeType() == shapeGoal && triggerable.GetMaterialType() == materialGoal)
        {
            Debug.Log("GIANT ENEMY GOAL GOT");
        }
        else
        {
            Debug.Log("TRY FLIPPING OVER FOR TONS OF DAMAGE");
        }
    }
}
