using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    public class Pickable: InteractableBase, Triggerable
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
            if (holder.held != this.gameObject)
            {
                Debug.Log("Holding");
                holder.SetHeld(this.gameObject);
                rigid.isKinematic = true;
            }
        }

        public virtual void DestroyRigid()
        {
            Destroy(rigid);
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
