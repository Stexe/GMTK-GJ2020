using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip orderUp;
    public AudioClip pickUp;
    public AudioClip drop;
    public AudioClip transformColor;
    public AudioClip transformOther;

    private void Awake()
    {
        DeliveryZone.onNewOrder.AddListener(o => Play(orderUp));
        Holder.onHeld.AddListener(o => Play(pickUp));
        Holder.onRelease.AddListener(o => Play(drop));
        ModificationSystem.onTransform.AddListener((b, t) => OnTransform(b, t));
    }

    private void Play(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, GameObject.Find("P_First_Person_Controller").transform.position);
    }

    private void OnTransform(Triggerable box, ChangeType type)
    {
        switch (type)
        {
            case ChangeType.COLOR_BLUE:
            case ChangeType.COLOR_GREY:
            case ChangeType.COLOR_RED:
            case ChangeType.COLOR_YELLOW:
                Play(transformColor);
                break;
            default:
                Play(transformOther);
                break;
        }
    }
}
