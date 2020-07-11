using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Effect_ChangeMaterial;

public class ModificationSystem : MonoBehaviour
{
    public MaterialPairing[] materialPairing;

    public Material getMaterial(MaterialType changeType)
    {
        return materialPairing.Single(mp => mp.materialType == changeType).material;
    }

    public static ModificationSystem get()
    {
        return FindObjectsOfType<ModificationSystem>()[0];
    }
}
