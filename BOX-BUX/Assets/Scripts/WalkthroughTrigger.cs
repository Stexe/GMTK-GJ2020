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
    public float cooldownSeconds = 1.1f;
    private float countdown;

    private void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Triggerable triggerable = other.GetComponent<Triggerable>();
        if (triggerable == null || countdown > 0)
        {
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            countdown = cooldownSeconds;
            ModificationSystem.MakeChange(triggerable, forwardChange);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            countdown = cooldownSeconds;
            ModificationSystem.MakeChange(triggerable, backwardChange);
        }
    }
}