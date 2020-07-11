using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VHS;

public class WalkthroughTrigger : MonoBehaviour
{
    public ChangeType forwardChange;
    public ChangeType backwardChange;

    public void OnTriggerEnter(Collider other)
    {
        Triggerable triggerable = other.GetComponent<Triggerable>();
        if(triggerable == null)
        {
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            ModificationSystem.MakeChange(triggerable, forwardChange);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ModificationSystem.MakeChange(triggerable, backwardChange);
        }
    }
}
