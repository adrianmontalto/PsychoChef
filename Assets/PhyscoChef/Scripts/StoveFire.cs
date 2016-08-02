using UnityEngine;
using System.Collections;

public class StoveFire : MonoBehaviour
{
    public float heat = 0.0f;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SaucePan")
        {

        }
    }
}
