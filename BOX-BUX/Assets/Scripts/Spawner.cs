﻿using System;
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
    public float secondsCooldown = 1.0f;
    public static EventTriggerable onSpawned;
    private GlobalState state;
    private float countdown;

    public SizeType defaultSize = SizeType.NORMAL;
    public ColorType defaultColor = ColorType.BLUE;
    public MaterialType defaultMaterial = MaterialType.METAL;
    public ShapeType defaultShape = ShapeType.CUBE;
    public bool randomSize;
    public bool randomColor;
    public bool randomMaterial;
    public bool randomShape;

    private void Awake()
    {
        state = FindObjectOfType<GlobalState>();
        onSpawned = new EventTriggerable();
    }

    private void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
    }

    public override void OnInteract()
    {
        if (state.spawned.Count >= state.spawnLimit || countdown > 0)
        {
            return;
        }

        countdown = secondsCooldown;
        var created = Instantiate(box);
        onSpawned.Invoke(created);

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
