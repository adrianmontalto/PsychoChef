using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour
{

    private Vector3 startPosition;
    private Quaternion startRotation;
	// Use this for initialization
	void Awake ()
    {
        startPosition = this.transform.position;
        startRotation = this.transform.rotation; 
	}

    public void ResetPostion()
    {
        if(this.gameObject.GetComponent<Food>())
        {
            this.gameObject.GetComponent<Food>().ResetFood();
        }
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;
    }
}
