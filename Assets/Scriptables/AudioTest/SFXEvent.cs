using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;
using Randon = UnityEngine.Random;

[CreateAssetMenu(menuName = "Sound/SFXEvent")]
public class SFXEvent : AudioEvent
{
    public AudioClip[] sFX;
    public AudioMixerGroup audioOutput;

    [MinMaxSlider(0f, 2f)]
    public float volume;

    [MinMaxSlider(0f, 2f)]
    public float pitch;

    public override void Play(AudioSource source)
    {
        if (sFX.Length == 0) { return; }

        source.clip = sFX[Random.Range(0 , sFX.Length)];
        source.volume = volume; 
        source.pitch = pitch;
        source.outputAudioMixerGroup = audioOutput;
        source.Play();
    }

    public void Play()
    {
        GameObject audioObject = new GameObject();
        AudioSource source = audioObject.AddComponent<AudioSource>();

        if (sFX.Length == 0) { return; }
    }
}
