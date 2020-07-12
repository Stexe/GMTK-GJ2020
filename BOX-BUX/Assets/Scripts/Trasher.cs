using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Internal;
using VHS;
using Random = UnityEngine.Random;

public class Trasher : MonoBehaviour
{
    public GlobalState state;

    private void Start()
    {
        state = FindObjectOfType<GlobalState>();
    }

    private void OnTriggerStay(Collider other)
    {
        Triggerable toTrash = other.GetComponent<Triggerable>();
        if (toTrash == null)
        {
            return;
        }
        Pickable pick = toTrash.asPickable();
        if (pick.holder.held != pick)
        {
            state.Trash(pick);
        }
    }
}
