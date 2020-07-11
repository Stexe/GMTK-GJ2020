using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace VHS {
    public enum Face
    {
        ONE, TWO, THREE, FOUR
    }
    public class PickableFace : InteractableBase
    {
        public Face face;
        public Rigidbody rigid;
        private PickableFaceObj parent;

        public void Awake()
        {
            parent = GetComponentInParent<PickableFaceObj>();
            Assert.IsNotNull(parent);
            rigid = GetComponent<Rigidbody>();
        }

        public override void OnInteract()
        {
            parent.OnFace(face);
        }
    }
}
