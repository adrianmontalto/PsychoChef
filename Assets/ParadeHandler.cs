using UnityEngine;
using System.Collections;

public class ParadeHandler : MonoBehaviour {

    private Confetti confetti;
    private ParadeMusicHandler music;

    private bool prevState;

	// Use this for initialization
	void Start ()
    {
        confetti = GetComponentInChildren<Confetti>();
        music = GetComponentInChildren<ParadeMusicHandler>();

        prevState = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (music.isPlaying() != prevState)
        {
            confetti.ChangeEmit(!prevState);
            prevState = music.isPlaying();
        }
	}

    public void PlayParade ()
    {
        music.PlayParadeMusic();
    }
}
