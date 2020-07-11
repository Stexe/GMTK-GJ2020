using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    public ColorType colorGoal;
    public MaterialType materialGoal;
    public ShapeType shapeGoal;

    private void Start()
    {
        Debug.Log("GOAL: " + materialGoal + ", " + colorGoal + ", " + shapeGoal);
    }

    public void OnTriggerEnter(Collider other)
    {
        Triggerable triggerable = other.GetComponent<Triggerable>();
        if (triggerable == null)
        {
            return;
        }
        if (triggerable.GetShapeType() == shapeGoal
            && triggerable.GetMaterialType() == materialGoal
            && triggerable.GetColorType() == colorGoal)
        {
            Debug.Log("GIANT ENEMY GOAL GOT");
        }
        else
        {
            Debug.Log("TRY FLIPPING OVER FOR TONS OF DAMAGE");
        }
    }
}
