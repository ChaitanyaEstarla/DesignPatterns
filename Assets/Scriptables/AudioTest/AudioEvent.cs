using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public abstract class AudioEvent : SerializedScriptableObject
{
    public virtual void Play(AudioSource source)
    {
        Debug.Log(source.name);
    }
}
