using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    public class PickableFaceObj : Pickable
    {
        public void OnFace()
        {
            base.OnInteract();
        }
    }
}