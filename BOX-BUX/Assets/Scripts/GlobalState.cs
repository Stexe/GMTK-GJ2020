using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class GlobalState : MonoBehaviour
{
    public int spawnLimit = 4;
    public List<Pickable> spawned = new List<Pickable>();

    public void OnSpawned(Pickable pickable)
    {
        spawned.Add(pickable);
    }

    public void Trash(Pickable toTrash)
    {
        if (!spawned.Remove(toTrash))
        {
            throw new System.Exception("Failed to trash: " + toTrash);
        }
        Destroy(toTrash.gameObject);
    }
}
