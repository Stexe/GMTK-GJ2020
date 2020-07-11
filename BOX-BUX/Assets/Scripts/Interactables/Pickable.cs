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
        public MaterialType materialType;
        public ShapeType shapeType;

        private void Awake()
        {
            holder = FindObjectOfType<Holder>();
            rigid = GetComponent<Rigidbody>();
        }

        public override void OnInteract()
        {
            if (holder.held == null)
            {
                holder.SetHeld(this.gameObject);
                rigid.isKinematic = true;
            }
        }

        public void SetMaterial(MaterialType type)
        {
            materialType = type;
            gameObject.GetComponent<MeshRenderer>().material = ModificationSystem.get().getMaterial(type);
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
        #endregion garbo

        public MaterialType GetMaterialType()
        {
            return materialType;
        }

        public ShapeType GetShapeType()
        {
            return shapeType;
        }
    }
}
