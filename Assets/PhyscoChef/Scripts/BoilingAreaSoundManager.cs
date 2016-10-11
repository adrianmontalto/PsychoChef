using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BoilingAreaSoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip boilingStage1Sound;
    [SerializeField]
    private AudioClip boilingStage2Sound;
    [SerializeField]
    private AudioClip splash;
    AudioSource audio;
	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void PlaySplash()
    {
        audio.PlayOneShot(splash, 0.7f);
    }

    public void PlayBoilSound()
    {
        audio.clip = boilingStage1Sound;
        audio.Play();
    }

    public void PlayBoilingSound()
    {
        audio.clip = boilingStage2Sound;
    }

    public void Stop()
    {
        audio.Stop();
    }
}
