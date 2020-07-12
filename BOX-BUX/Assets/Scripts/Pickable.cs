using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class Pickable : InteractableBase, Triggerable
{
    public Holder holder;
    public Rigidbody rigid;
    public ColorType colorType;
    public MaterialType materialType;
    public ShapeType shapeType;
    public SizeType sizeType;
    public Spawner spawner;

    private void Awake()
    {
        holder = FindObjectOfType<Holder>();
        rigid = GetComponent<Rigidbody>();
    }

    public override void OnInteract()
    {
        if (holder.held == null)
        {
            holder.SetHeld(this);
            rigid.isKinematic = true;
        }
    }

    public void SetMaterial(MaterialType type)
    {
        SetMaterialAndColor(type, colorType);
    }

    public void SetColor(ColorType type)
    {
        SetMaterialAndColor(materialType, type);
    }

    private void SetMaterialAndColor(MaterialType materialType, ColorType colorType)
    {
        ColorAndMaterialType? type = null;
        switch (materialType)
        {
            case MaterialType.ABSTRACT:
                switch (colorType)
                {
                    case ColorType.BLUE:
                        type = ColorAndMaterialType.ABSTRACT_BLUE;
                        break;
                    case ColorType.GREY:
                        type = ColorAndMaterialType.ABSTRACT_GREY;
                        break;
                    case ColorType.RED:
                        type = ColorAndMaterialType.ABSTRACT_RED;
                        break;
                    case ColorType.YELLOW:
                        type = ColorAndMaterialType.ABSTRACT_YELLOW;
                        break;
                }
                break;
            case MaterialType.CHECKERED:
                switch (colorType)
                {
                    case ColorType.BLUE:
                        type = ColorAndMaterialType.CHECKERED_BLUE;
                        break;
                    case ColorType.GREY:
                        type = ColorAndMaterialType.CHECKERED_GREY;
                        break;
                    case ColorType.RED:
                        type = ColorAndMaterialType.CHECKERED_RED;
                        break;
                    case ColorType.YELLOW:
                        type = ColorAndMaterialType.CHECKERED_YELLOW;
                        break;
                }
                break;
            case MaterialType.MATTE:
                switch (colorType)
                {
                    case ColorType.BLUE:
                        type = ColorAndMaterialType.MATTE_BLUE;
                        break;
                    case ColorType.GREY:
                        type = ColorAndMaterialType.MATTE_GREY;
                        break;
                    case ColorType.RED:
                        type = ColorAndMaterialType.MATTE_RED;
                        break;
                    case ColorType.YELLOW:
                        type = ColorAndMaterialType.MATTE_YELLOW;
                        break;
                }
                break;
            case MaterialType.METAL:
                switch (colorType)
                {
                    case ColorType.BLUE:
                        type = ColorAndMaterialType.METAL_BLUE;
                        break;
                    case ColorType.GREY:
                        type = ColorAndMaterialType.METAL_GREY;
                        break;
                    case ColorType.RED:
                        type = ColorAndMaterialType.METAL_RED;
                        break;
                    case ColorType.YELLOW:
                        type = ColorAndMaterialType.METAL_YELLOW;
                        break;
                }
                break;
        }
        if (type == null)
        {
            throw new System.Exception("missing combination for: " + colorType + ", " + materialType);
        }
        this.colorType = colorType;
        this.materialType = materialType;
        GetComponent<MeshRenderer>().material = ModificationSystem.get().getMaterial(type.Value).material;
    }

    public void SetShape(ShapeType type)
    {
        if (shapeType == type)
        {
            return;
        }
        bool cube = type == ShapeType.CUBE;
        var faces = GetComponentsInChildren<PickableFace>();
        foreach (var face in faces)
        {
            face.GetComponent<BoxCollider>().enabled = cube;
        }
        isInteractable = !cube;

        var shape = ModificationSystem.get().getShape(type);
        gameObject.GetComponent<MeshFilter>().mesh = shape.mesh;
        gameObject.GetComponent<MeshCollider>().sharedMesh = shape.mesh;
    }

    public void SetSize(SizeType type)
    {
        float scale;
        switch (type)
        {
            case SizeType.NORMAL:
                scale = 1;
                break;
            case SizeType.SMALL:
                scale = 0.75f;
                break;
            case SizeType.XSMALL:
                scale = 0.5f;
                break;
            case SizeType.BIG:
                scale = 1.25f;
                break;
            case SizeType.XBIG:
                scale = 1.5f;
                break;
            default:
                throw new System.Exception("No functionality for SizeType: " + type);
        }
        transform.localScale = new Vector3(1, 1, 1) * scale;
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

    public ColorType GetColorType()
    {
        return colorType;
    }

    public ShapeType GetShapeType()
    {
        return shapeType;
    }

    public Pickable asPickable()
    {
        return this;
    }
}
