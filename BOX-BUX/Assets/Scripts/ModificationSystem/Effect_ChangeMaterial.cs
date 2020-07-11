using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_ChangeMaterial : Effect
{
    [Serializable]
    public class MaterialPairing
    {
        [SerializeField]
        public MaterialType materialType;
        [SerializeField]
        public Material material;
    }

    public Material changeTo;

    public Effect_ChangeMaterial(Material changeTo)
    {
        this.changeTo = changeTo;
    }

    public void ExecuteEffect(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material = changeTo;
    }
}