using UnityEngine;
using System.Collections;

public class ParadeMusicHandler : MonoBehaviour {

    private Vector3 startPoint;
    private Vector3 endPoint;
    private Transform musicPosition;
    private AudioSource musicSource;
    private float musicLength;

	// Use this for initialization
	void Start ()
    {
        Transform[] transforms = GetComponentsInChildren<Transform>();

        for (int i = 0; i < transforms.Length; i++)
        {
            if (transforms[i].name == "Point1")
            {
                startPoint = transforms[i].position;
            }
            else if (transforms[i].name == "Point2")
            {
                endPoint = transforms[i].position;
            }
            else if (transforms[i].name == "AudioSource")
            {
                musicPosition = transforms[i];
                musicSource = musicPosition.GetComponent<AudioSource>();
            }
        }

        musicLength = musicSource.clip.length;
        musicPosition.position = startPoint;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (musicSource.isPlaying == true)
        {
            musicPosition.position = Vector3.Lerp(startPoint, endPoint, musicSource.time/musicLength);
        }
	}

    public void PlayParadeMusic ()
    {
        musicSource.Play();
        musicPosition.position = startPoint;
    }

    public bool isPlaying ()
    {
        return musicSource.isPlaying;
    }
}
