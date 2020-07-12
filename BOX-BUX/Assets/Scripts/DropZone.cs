using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    private class ChangingState
    {
        public float countdown;
        public bool changing;

        public ChangingState(float countdown, bool changing)
        {
            this.countdown = countdown;
            this.changing = changing;
        }
    }

    public ChangeType changeType;
    public float secondsToChange = 0.5f;
    private Dictionary<Pickable, ChangingState> countdowns = new Dictionary<Pickable, ChangingState>();

    private void Update()
    {
        foreach(var box in countdowns.Keys.ToList())
        {
            var state = countdowns[box];
            if (!state.changing)
            {
                countdowns.Remove(box);
                continue;
            }
            state.countdown -= Time.deltaTime;
            if(state.countdown <= 0)
            {
                countdowns.Remove(box);
                ModificationSystem.MakeChange(box, changeType);
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        Triggerable triggerable = other.GetComponent<Triggerable>();
        if (triggerable == null)
        {
            return;
        }
        Pickable toChange = triggerable.asPickable();

        if (!countdowns.ContainsKey(toChange))
        {
            countdowns.Add(toChange, new ChangingState(secondsToChange, toChange.holder.held != toChange));
        }
    }
}
