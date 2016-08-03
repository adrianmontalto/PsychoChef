using UnityEngine;
using System.Collections;

public class StoveKnob : MonoBehaviour
{
    public StoveFire stoveFire;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision col)
    {
        //check to see if the hand has hit the object
        if (col.gameObject.tag == "Hand")
        {
            Debug.Log("stoveLit");
            stoveFire.GetComponent<Renderer>().enabled = true;
        }
    }
}
