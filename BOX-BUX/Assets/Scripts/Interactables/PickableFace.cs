using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using static Effect_ChangeMaterial;

namespace VHS {
    public class PickableFace : InteractableBase
    {
        public MaterialType materialType;
        
        private PickableFaceObj parent;
        private Material material;

        public void Awake()
        {
            parent = GetComponentInParent<PickableFaceObj>();
            Assert.IsNotNull(parent);
            material = ModificationSystem.get().getMaterial(materialType);
        }

        public override void OnInteract()
        {
            if (parent.holder.held == null)
            {
                // avoid setting material on drop
                parent.GetComponent<MeshRenderer>().material = material;
            }
            parent.OnFace();
        }
    }
}
