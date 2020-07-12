using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class GlobalState : MonoBehaviour
{
    public int spawnLimit = 4;
    public List<Pickable> spawned = new List<Pickable>();
    public GameObject facesZone;
    public SightZone sightZone;

    public static GlobalState get()
    {
        return FindObjectOfType<GlobalState>();
    }

    private void OnSpawned(Triggerable box)
    {
        spawned.Add(box.asPickable());
    }

    private void Start()
    {
        Trasher.onTrashed.AddListener(Trash);
        Spawner.onSpawned.AddListener(OnSpawned);
    }

    private void Trash(Triggerable toTrash)
    {
        if (!spawned.Remove(toTrash.asPickable()))
        {
            throw new System.Exception("Failed to trash: " + toTrash);
        }
    }
}
