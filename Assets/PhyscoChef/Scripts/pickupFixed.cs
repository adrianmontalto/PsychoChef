using UnityEngine;
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
	void FixedUpdate ()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    void OnTriggerStay(Collider col)
    {
        if(fixedJoint == null && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            fixedJoint = col.gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = rigidBodyAttachPoint;
        }
        else if(fixedJoint !=null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject go = fixedJoint.gameObject;
            Rigidbody rigidbody = go.GetComponent<Rigidbody>();
            Object.Destroy(fixedJoint);
            fixedJoint = null;
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
            rigidbody.velocity = origin.TransformVector(device.velocity);
            rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
        }
    }
}
