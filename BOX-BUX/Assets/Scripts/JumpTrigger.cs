using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public float yOffset;
    public ChangeType changeType;
    private Pickable parent;

    private void Start()
    {
        parent = transform.parent.gameObject.GetComponent<Pickable>();
    }

    private void Update()
    {
        Vector3 pos = parent.transform.position;
        transform.position = new Vector3(pos.x, pos.y + yOffset, pos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<CharacterController>();
        if (player != null)
        {
            ModificationSystem.MakeChange(parent, changeType);
        }
    }
}
