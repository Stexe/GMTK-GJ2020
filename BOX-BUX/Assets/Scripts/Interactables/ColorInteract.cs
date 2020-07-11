using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    public class ColorInteract : InteractableBase
    {
        Material changeMaterial;
        void OnCollisionEnter(Collision collision)
        {
            collision.gameObject.GetComponent<Renderer>().material = changeMaterial;
        }
    }
}