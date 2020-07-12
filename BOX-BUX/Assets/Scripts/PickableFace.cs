using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace VHS {
    public class PickableFace : InteractableBase
    {
        public ChangeType changeType;
        
        private PickableFaceObj parent;

        public void Awake()
        {
            parent = GetComponentInParent<PickableFaceObj>();
            Assert.IsNotNull(parent);
        }

        public override void OnInteract()
        {
            bool inFacesZone = GlobalState.get().facesZone.GetComponent<Collider>().bounds.Intersects(parent.GetComponent<Collider>().bounds);
            if (parent.holder.held == null && inFacesZone)
            {
                ModificationSystem.MakeChange(parent, changeType);
            }
            parent.OnFace();
        }
    }
}
