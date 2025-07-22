using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager singleton;
    public AudioClip[] clips;
    AudioSource audSrc;

    public void Awake()
    {
        singleton = this;
        audSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(int clipIndex)
    {
        audSrc.PlayOneShot(clips[clipIndex]);
    }
}

