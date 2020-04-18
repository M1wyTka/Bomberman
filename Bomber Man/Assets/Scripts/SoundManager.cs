using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    public AudioClip Explosion;
    public AudioClip Hurt;
    public AudioClip Upgrade;
    public AudioClip PowerUp;
    public AudioClip Teleportation;
    public AudioClip Confirm;

    private AudioSource soundEffectAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
            Destroy(gameObject);
        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;
    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }
}
