using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    [RequireComponent(typeof(Rigidbody))]
    public class Pickable: InteractableBase
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
            if (holder.held != this)
            {
                Debug.Log("Holding");
                holder.SetHeld(this);
                rigid.isKinematic = true;
            }
        }

        #region garbo

        public void OnHold()
        {

        }

        public void OnPickUp()
        {
        }

        public void OnRelease()
        {
            
        }
    }
#endregion garbo
}
