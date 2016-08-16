﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class pickupFixed : MonoBehaviour
{
    public Rigidbody rigidBodyAttachPoint;
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    FixedJoint fixedJoint = null;

    // Use this for initialization
    void Awake ()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    void OnTriggerStay(Collider col)
    {

        if (fixedJoint == null && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            //adds a fixed joint to the colliding object
            fixedJoint = col.gameObject.AddComponent<FixedJoint>();
            //connects the object toi the hand
            fixedJoint.connectedBody = rigidBodyAttachPoint;
            col.attachedRigidbody.isKinematic = true;
            Debug.Log("pick up object");
        }

        //checks to see if there is a fixed joint and that the trigger is not held
        if(fixedJoint !=null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            //sets the objects kinematic to false
            col.attachedRigidbody.isKinematic = false;
            //sets a gameobject top the attached object
            GameObject go = fixedJoint.gameObject;
            //sets a rigid body to the attached objects rigidbody
            Rigidbody rigidbody = go.GetComponent<Rigidbody>();
            //destroys the fixed joint
            Object.Destroy(fixedJoint);
            //nulls the fixed joint
            fixedJoint = null;
            //throws object
            TossObject(rigidbody);
        }
    }

    void TossObject(Rigidbody rigidbody)
    {
        //convert local space vectors to world space vectors
        //
        //define origin to define conversion
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;

        //check to see if origin is not null
        if (origin != null)
        {
            //throws the object using the controllers velocity
            rigidbody.velocity = origin.TransformVector(device.velocity);
            rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //checks to see if the hand has hit the stove
        if (other.tag == "StoveKnob")
        {
            //sets the heating area
            other.GetComponent<StoveKnob>().SetActive();
        }
    }
}
