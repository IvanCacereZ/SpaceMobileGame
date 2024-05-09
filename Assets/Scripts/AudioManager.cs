using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource audioManger;
    public AudioSource sfxManager;

    [Header("Clips")]
    public AudioClip LobbyMusic;
    public AudioClip GameMusic;
    public AudioClip clipSFX;

    private void Start()
    {
        audioManger.loop = true;
    }
    public void ReproduceLobbyMusic()
    {
        audioManger.Stop();
        audioManger.clip = LobbyMusic;
        audioManger.Play();
    }
    public void ReproduceGameMusic()
    {
        audioManger.Stop();
        audioManger.clip = GameMusic;
        audioManger.Play();
    }
    public void SfxClip()
    {
        sfxManager.Stop();
        sfxManager.clip = clipSFX;
        sfxManager.Play();
    }
}
