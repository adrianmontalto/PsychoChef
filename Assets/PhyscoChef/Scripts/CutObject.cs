using UnityEngine;
using System.Collections;

public class CutObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Food")
        {
            if (col.gameObject.GetComponent<SlicedObject>().GetRecentlySliced() == false)
            {
                StartCoroutine(BLINDED_AM_ME.MeshCut.Cut(col.gameObject, transform.position, transform.up, col.gameObject.GetComponentInChildren<Renderer>().material));
            }
        }
    }
}
