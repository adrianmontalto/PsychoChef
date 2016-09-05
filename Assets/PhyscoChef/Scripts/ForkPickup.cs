using UnityEngine;
using System.Collections;

public class ForkPickup : MonoBehaviour
{
    FixedJoint fixedJoint;


	// Use this for initialization
	void Start ()
    {

	}
	

	// Update is called once per frame
	void Update ()
    {

	}


    void OnTriggerEnter (Collider other)
    {
        fixedJoint = gameObject.AddComponent<FixedJoint>();

        fixedJoint.breakForce = 1000;

        fixedJoint.connectedBody = other.transform.root.GetComponent<Rigidbody>();
    }

    void OnJointBreak (float breakForce)
    {
        Destroy(fixedJoint);
    }
}
