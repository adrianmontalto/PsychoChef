using UnityEngine;
using System.Collections;

public class FireEmiter : MonoBehaviour {

    private ParticleSystem.EmissionModule[] emiters;
    private ParticleSystem[] particleSystems;

	// Use this for initialization
	void Start ()
    {
        //emiters = GetComponentsInChildren<ParticleSystem.EmissionModule>();
        particleSystems = GetComponentsInChildren<ParticleSystem>();
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
}
