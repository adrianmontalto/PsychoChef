using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    //always called before any start functions and also just after a prefab is instatiated(if gameobject is inactive during start up awake is not called until it is made active)
    void Awake ()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
    //called for every frame
	void FixedUpdate ()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        //if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        //{
        //    Debug.Log("holding down touch trigger");
        //}
        //if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        //{
        //    Debug.Log("activated touch down");
        //}
        //if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        //{
        //    Debug.Log("activated touch up");
        //}
    }

    void OntriggerStay(Collider col)
    {
        Debug.Log("you have collided with" + col.name + "and activated on trigger stay");
        if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("you have collided with" + col.name +  "while holding down touch");
            col.attachedRigidbody.isKinematic = true;
            col.gameObject.transform.SetParent(this.gameObject.transform);
        }

        if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("you have released touch while colliding with" + col.name);
            col.gameObject.transform.SetParent(null);
            col.attachedRigidbody.isKinematic = false;
        }
    }
}
