using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Internal;
using VHS;
using Random = UnityEngine.Random;

public class Spawner : InteractableBase
{
    public Pickable box;
    public Vector3 spawnPosition;

    public List<Pickable> spawned = new List<Pickable>();

    public int boxLimit = 4;

    public SizeType defaultSize = SizeType.NORMAL;
    public ColorType defaultColor = ColorType.BLUE;
    public MaterialType defaultMaterial = MaterialType.METAL;
    public ShapeType defaultShape = ShapeType.CUBE;
    public bool randomSize;
    public bool randomColor;
    public bool randomMaterial;
    public bool randomShape;

    public override void OnInteract()
    {
        if (spawned.Count >= boxLimit)
        {
            return;
        }
        var created = Instantiate(box);
        spawned.Add(created);


        if (randomSize)
        {
            created.SetSize(randomEnum<SizeType>());
        }
        else
        {
            created.SetSize(defaultSize);
        }
        if (randomColor)
        {
            created.SetColor(randomEnum<ColorType>());
        }
        else
        {
            created.SetColor(defaultColor);
        }
        if (randomMaterial)
        {
            created.SetMaterial(randomEnum<MaterialType>());
        }
        else
        {
            created.SetMaterial(defaultMaterial);
        }
        if (randomShape)
        {
            created.SetShape(randomEnum<ShapeType>());
        }
        else
        {
            created.SetShape(defaultShape);
        }
        created.transform.position = spawnPosition;
    }

    private static T randomEnum<T>()
    {
        var enums = Enum.GetValues(typeof(T));
        return (T)enums.GetValue(Random.Range(0, enums.Length));
    }
}
