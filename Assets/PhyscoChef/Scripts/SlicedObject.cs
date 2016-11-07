using UnityEngine;
using System.Collections;

public class SlicedObject : MonoBehaviour {

    bool recentlySliced = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SetAsRecentlySliced()
    {
        recentlySliced = true;
    }

    public bool GetRecentlySliced()
    {
        return recentlySliced;
    }

    void OnCollisionExit (Collision col)
    {
        if (col.gameObject.tag == "Knife")
        {
            recentlySliced = false;
        }
    }
}
