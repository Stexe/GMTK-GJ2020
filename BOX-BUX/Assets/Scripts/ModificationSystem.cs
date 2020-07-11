using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModificationSystem : MonoBehaviour
{
    public MaterialPairing[] materialPairing;
    public ShapePairing[] shapePairing;

    public MaterialPairing getMaterial(MaterialType changeType)
    {
        return materialPairing.Single(mp => mp.type == changeType);
    }

    public ShapePairing getShape(ShapeType shapeType)
    {
        return shapePairing.Single(sp => sp.type == shapeType);
    }

    public static void MakeChange(Triggerable triggerable, ChangeType type)
    {
        MaterialType? material = null;
        ShapeType? shape = null;
        SizeType? size = null;
        switch (type)
        {
            case ChangeType.MAT_MATTE_GREY:
                material = MaterialType.MATTE_GREY;
                break;
            case ChangeType.MAT_MATTE_RED:
                material = MaterialType.MATTE_RED;
                break;
            case ChangeType.MAT_MATTE_BLUE:
                material = MaterialType.MATTE_BLUE;
                break;
            case ChangeType.MAT_MATTE_YELLOW:
                material = MaterialType.MATTE_YELLOW;
                break;
            case ChangeType.MAT_METAL_GREY:
                material = MaterialType.METAL_GREY;
                break;
            case ChangeType.MAT_METAL_RED:
                material = MaterialType.METAL_RED;
                break;
            case ChangeType.MAT_METAL_BLUE:
                material = MaterialType.METAL_BLUE;
                break;
            case ChangeType.MAT_METAL_YELLOW:
                material = MaterialType.METAL_YELLOW;
                break;
            case ChangeType.MAT_CHECKERED_GREY:
                material = MaterialType.CHECKERED_GREY;
                break;
            case ChangeType.MAT_CHECKERED_RED:
                material = MaterialType.CHECKERED_RED;
                break;
            case ChangeType.MAT_CHECKERED_BLUE:
                material = MaterialType.CHECKERED_BLUE;
                break;
            case ChangeType.MAT_CHECKERED_YELLOW:
                material = MaterialType.CHECKERED_YELLOW;
                break;
            case ChangeType.MAT_ABSTRACT_GREY:
                material = MaterialType.ABSTRACT_GREY;
                break;
            case ChangeType.MAT_ABSTRACT_RED:
                material = MaterialType.ABSTRACT_RED;
                break;
            case ChangeType.MAT_ABSTRACT_BLUE:
                material = MaterialType.ABSTRACT_BLUE;
                break;
            case ChangeType.MAT_ABSTRACT_YELLOW:
                material = MaterialType.ABSTRACT_YELLOW;
                break;
            case ChangeType.SHAPE_CUBE:
                shape = ShapeType.CUBE;
                break;
            case ChangeType.SHAPE_DODECAHEDRON:
                shape = ShapeType.DODECAHEDRON;
                break;
            case ChangeType.SHAPE_OCTAHEDRON:
                shape = ShapeType.OCTAHEDRON;
                break;
            case ChangeType.SHAPE_TETRAHEDRON:
                shape = ShapeType.TETRAHEDRON;
                break;
            case ChangeType.SIZE_BIG:
                size = SizeType.BIG;
                break;
            case ChangeType.SIZE_NORMAL:
                size = SizeType.NORMAL;
                break;
            case ChangeType.SIZE_SMALL:
                size = SizeType.SMALL;
                break;
            case ChangeType.SIZE_XBIG:
                size = SizeType.XBIG;
                break;
            case ChangeType.SIZE_XSMALL:
                size = SizeType.XSMALL;
                break;
            default:
                throw new System.Exception("unhandled ChangeType: " + type);
        }

        if (shape != null)
        {
            triggerable.SetShape(shape.Value);
        }
        else if (material != null)
        {
            triggerable.SetMaterial(material.Value);
        }
        else if(size != null)
        {
            triggerable.SetSize(size.Value);
        }
    }

    public static ModificationSystem get()
    {
        return FindObjectsOfType<ModificationSystem>()[0];
    }
}
