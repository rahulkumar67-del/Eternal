using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager instance {  get; private set; }

    public AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
        instance = this;
    }


    public void playsound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
