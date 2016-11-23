using UnityEngine;
using System.Collections;

public class FireEmiter : MonoBehaviour {

    private ParticleSystem[] particleSystems;

    private float maxFireSize = 0.3f;
    private float maxFireSpeed = 1.0f;
    private float minFireSize = 0.15f;
    private float minFireSpeed = 0.5f;

    private float sizeDiff;
    private float speedDiff;

    // Use this for initialization
    void Start ()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();

        sizeDiff = maxFireSize - minFireSize;
        speedDiff = maxFireSpeed - minFireSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ChangeEmit (bool state)
    {
        if (state == true)
        {
            for (int i = 0; i < particleSystems.Length; ++i)
            {
                particleSystems[i].Play();
                //emiters[i].enabled = state;
            }
        }
        else
        {
            for (int i = 0; i < particleSystems.Length; ++i)
            {
                particleSystems[i].Stop();
            }
        }
    }

    public void ChangeSizeNSpeed (float percent)
    {
        float newSize = minFireSize + (sizeDiff * percent);
        float newSpeed = minFireSpeed + (speedDiff * percent);

        for (int i = 0; i < particleSystems.Length; ++i)
        {
            particleSystems[i].startSize = newSize;
            particleSystems[i].startSpeed = newSpeed;
        }
    }
}
