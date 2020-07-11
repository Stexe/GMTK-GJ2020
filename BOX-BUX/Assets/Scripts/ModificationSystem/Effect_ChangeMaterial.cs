using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_ChangeMaterial : Effect
{
    [Serializable]
    public enum ChangeType
    {
        MATTE_GREY, MATTE_RED, MATTE_BLUE, MATTE_YELLOW,
        METAL_GREY, METAL_RED, METAL_BLUE, METAL_YELLOW,
        CHECKERED_GREY, CHECKERED_RED, CHECKERED_BLUE, CHECKERED_YELLOW,
        ABSTRACT_GREY, ABSTRACT_RED, ABSTRACT_BLUE, ABSTRACT_YELLOW,
    }

    [Serializable]
    public class MaterialPairing
    {
        [SerializeField]
        public ChangeType changeType;
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
