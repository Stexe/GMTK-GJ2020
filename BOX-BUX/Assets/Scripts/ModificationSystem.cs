using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModificationSystem : MonoBehaviour
{
    public static EventTransform onTransform = new EventTransform();

    public MaterialPairing[] materialPairing;
    public ShapePairing[] shapePairing;

    public MaterialPairing getMaterial(ColorAndMaterialType changeType)
    {
        return materialPairing.Single(mp => mp.type == changeType);
    }

    public ShapePairing getShape(ShapeType shapeType)
    {
        return shapePairing.Single(sp => sp.type == shapeType);
    }

    public static void MakeChange(Triggerable triggerable, ChangeType type)
    {
        ColorType? color = null;
        MaterialType? material = null;
        ShapeType? shape = null;
        SizeType? size = null;
        switch (type)
        {
            case ChangeType.COLOR_GREY:
                color = ColorType.GREY;
                break;
            case ChangeType.COLOR_BLUE:
                color = ColorType.BLUE;
                break;
            case ChangeType.COLOR_RED:
                color = ColorType.RED;
                break;
            case ChangeType.COLOR_YELLOW:
                color = ColorType.YELLOW;
                break;
            case ChangeType.MAT_ABSTRACT:
                material = MaterialType.ABSTRACT;
                break;
            case ChangeType.MAT_CHECKERED:
                material = MaterialType.CHECKERED;
                break;
            case ChangeType.MAT_MATTE:
                material = MaterialType.MATTE;
                break;
            case ChangeType.MAT_METAL:
                material = MaterialType.METAL;
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
            case ChangeType.SIZE_DECREASE:
                switch (triggerable.GetSizeType())
                {
                    case SizeType.XBIG:
                        size = SizeType.BIG;
                        break;
                    case SizeType.BIG:
                        size = SizeType.NORMAL;
                        break;
                    case SizeType.NORMAL:
                        size = SizeType.SMALL;
                        break;
                    case SizeType.SMALL:
                        size = SizeType.XSMALL;
                        break;
                }
                break;
            case ChangeType.SIZE_INCREASE:
                switch (triggerable.GetSizeType())
                {
                    case SizeType.BIG:
                        size = SizeType.XBIG;
                        break;
                    case SizeType.NORMAL:
                        size = SizeType.BIG;
                        break;
                    case SizeType.SMALL:
                        size = SizeType.NORMAL;
                        break;
                    case SizeType.XSMALL:
                        size = SizeType.SMALL;
                        break;
                }
                break;
            default:
                throw new System.Exception("unhandled ChangeType: " + type);
        }

        bool transformed = false;
        if (shape != null && triggerable.GetShapeType() != shape)
        {
            triggerable.SetShape(shape.Value);
            transformed = true;
        }
        else if (color != null && triggerable.GetColorType() != color)
        {
            triggerable.SetColor(color.Value);
            transformed = true;
        }
        else if (material != null && triggerable.GetMaterialType() != material)
        {
            triggerable.SetMaterial(material.Value);
            transformed = true;
        }
        else if (size != null && triggerable.GetSizeType() != size)
        {
            triggerable.SetSize(size.Value);
            transformed = true;
        }

        if (transformed)
        {
            onTransform.Invoke(triggerable, type);
        }
    }

    public static ModificationSystem get()
    {
        return FindObjectsOfType<ModificationSystem>()[0];
    }
}
