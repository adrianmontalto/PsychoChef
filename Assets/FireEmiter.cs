using UnityEngine;
using System.Collections;

public class FireEmiter : MonoBehaviour {

    private ParticleSystem.EmissionModule[] emiters;

	// Use this for initialization
	void Start ()
    {
        emiters = GetComponentsInChildren<ParticleSystem.EmissionModule>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ChangeEmit (bool state)
    {
        for (int i = 0; i < emiters.Length; ++i)
        {
            emiters[i].enabled = state;
        }
    }
}
