using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VHS;
using static Effect_ChangeMaterial;

public class WalkthroughTrigger : MonoBehaviour
{
    public MaterialType forwardChangeType;
    public MaterialType backwardChangeType;
    private Material forwardChange;
    private Material backwardChange;

    public void Start()
    {
        forwardChange = ModificationSystem.get().getMaterial(forwardChangeType);
        backwardChange = ModificationSystem.get().getMaterial(backwardChangeType);
    }

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
            other.GetComponent<MeshRenderer>().material = forwardChange;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Trigger backwards");
            other.GetComponent<MeshRenderer>().material = backwardChange;
        }
    }
}
