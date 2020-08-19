using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    public void PlayClip(AudioClip clip, float volume)
    {
        GetComponent<AudioSource>().PlayOneShot(clip, volume);
    }
    public void PlayDesignatedClip(string clipName, float volume)
    {
        var found = false;
        foreach (AudioClip clip in audioClips)
        {
            if (clip.name == clipName)
            {
                GetComponent<AudioSource>().PlayOneShot(clip, volume);
                found = true;
            }
            if (found) break;
        }
    }
}
