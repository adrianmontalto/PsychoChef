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
            GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(col.gameObject, transform.position, transform.right, col.gameObject.GetComponent<Renderer>().material);

            for (int i = 1; i < pieces.Length; i++)
            {
                if (!pieces[i].GetComponent<Rigidbody>())
                {
                    pieces[i].AddComponent<Rigidbody>();
                    pieces[i].name = "CutChicken";
                    pieces[i].tag = "Food";
                    //change layer
                }
            }
        }
    }
}
