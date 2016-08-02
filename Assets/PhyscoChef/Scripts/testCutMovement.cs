using UnityEngine;
using System.Collections;

public class testCutMovement : MonoBehaviour
{
    public Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey("up"))
        {
            Debug.Log("up");
            rb.AddForce(0, 0, 1);
        }
        if (Input.GetKey("down"))
        {
            Debug.Log("down");
            rb.AddForce(0, 0, -1);
        }
        if (Input.GetKey("left"))
        {
            Debug.Log("left");
            rb.AddForce(1, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            Debug.Log("right");
            rb.AddForce(-1, 0, 0);
        }
    }
}
