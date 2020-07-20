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
        Trasher.onTrashed.AddListener(OnTrash);
        Spawner.onSpawned.AddListener(OnSpawned);
        DeliveryZone.onDelivered.AddListener(OnDeliver);
    }

    private void OnTrash(Triggerable toTrash)
    {
        if (!spawned.Remove(toTrash.asPickable()))
        {
            throw new System.Exception("Failed to trash: " + toTrash);
        }
    }

    private void OnDeliver(Triggerable delivered)
    {
        if (!spawned.Remove(delivered.asPickable()))
        {
            throw new System.Exception("Failed to despawn delivered: " + delivered);
        }
    }
}
