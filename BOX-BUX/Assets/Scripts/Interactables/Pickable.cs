using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    [RequireComponent(typeof(Rigidbody))]
    public class Pickable : InteractableBase
    {
        public Holder holder;
        public Rigidbody rigid;

        private void Awake()
        {
            holder = FindObjectOfType<Holder>();
            rigid = GetComponent<Rigidbody>();
        }

        public override void OnInteract()
        {
            if (holder.held != gameObject && holder.releasing == false)
            {
                Debug.Log("Holding");
                holder.SetHeld(this);
            }
        }

        public void OnHold()
        {
            Debug.Log("onhold");

        }

        public void OnPickUp()
        {
            Debug.Log("OnPickUp");
        }

        public void OnRelease()
        {
            
        }
    }
}
