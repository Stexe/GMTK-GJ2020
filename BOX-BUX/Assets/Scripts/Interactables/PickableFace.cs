using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace VHS {
    public class PickableFace : InteractableBase
    {
        public MaterialType materialType;
        
        private PickableFaceObj parent;

        public void Awake()
        {
            parent = GetComponentInParent<PickableFaceObj>();
            Assert.IsNotNull(parent);
        }

        public override void OnInteract()
        {
            if (parent.holder.held == null)
            {
                // avoid setting material on drop
                parent.SetMaterial(materialType);
            }
            parent.OnFace();
        }
    }
}
