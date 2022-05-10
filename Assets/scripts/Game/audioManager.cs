using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.Play();
    }
}
