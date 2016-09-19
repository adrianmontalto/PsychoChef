using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class pickupFixed : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    FixedJoint fixedJoint;

    bool grab = false;

    // Use this for initialization
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    void Update()
    {
        if (device.GetHairTriggerUp() == true)
        {
            Destroy(fixedJoint);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (fixedJoint == null)
        {

            // (SteamVR_Controller.ButtonMask.Trigger)
            if (device.GetHairTriggerDown() == true)
            {
                fixedJoint = gameObject.AddComponent<FixedJoint>();

                fixedJoint.connectedBody = col.gameObject.GetComponent<Rigidbody>();

                if (fixedJoint.connectedBody == null)
                {
                    fixedJoint.connectedBody = col.gameObject.GetComponentInParent<Rigidbody>();
                }

                if (fixedJoint.connectedBody == null)
                {
                    Destroy(fixedJoint);
                    return;
                }

                fixedJoint.breakForce = 100000;
            }
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

        if (other.tag == "Finish")
        {
            other.GetComponent<Bell>().SetDone(true);
        }
    }
}