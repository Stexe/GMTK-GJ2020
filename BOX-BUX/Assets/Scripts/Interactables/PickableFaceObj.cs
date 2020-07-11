using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    public class PickableFaceObj : Pickable
    {
        public void OnFace(Face face)
        {
            Debug.Log(face);
            base.OnInteract();
        }
    }
}