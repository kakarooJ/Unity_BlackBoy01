using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;

    public AudioClip audioClipExplosion;
    public AudioClip audioClipIncHp;
    public AudioClip audioClipJump;
    public AudioClip audioClipPop;
    public AudioClip audioClipRolling;

    void Awake() {
        if(AudioManager.instance == null) {
            AudioManager.instance = this;
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void playExplosion() {
        audioSource.PlayOneShot(audioClipExplosion);
    }

    public void playIncHp() {
        audioSource.PlayOneShot(audioClipIncHp);
    }

    public void playJump() {
        audioSource.PlayOneShot(audioClipJump);
    }

    public void playPop() {
        audioSource.PlayOneShot(audioClipPop);
    }

    public void playRolling() {
        audioSource.PlayOneShot(audioClipRolling);
    }
}
