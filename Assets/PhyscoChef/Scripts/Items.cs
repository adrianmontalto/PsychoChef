using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour
{

    private Vector3 startPosition;
	// Use this for initialization
	void Awake ()
    {
        startPosition = this.transform.position; 
	}

    public void ResetPostion()
    {
        if(this.gameObject.GetComponent<Food>())
        {
            this.gameObject.GetComponent<Food>().ResetFood();
        }
        this.transform.position = startPosition;
    }
}
