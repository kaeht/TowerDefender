using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance { get; private set; }

    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }
}
