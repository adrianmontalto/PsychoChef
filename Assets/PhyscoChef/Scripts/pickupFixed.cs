using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class pickupFixed : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    FixedJoint fixedJoint;

    GameObject nearestObject;

    float nearestObjectDistance;

    // Use this for initialization
    void Start()
    {
    }

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
        if (fixedJoint != null)
        {
            if (device.GetHairTriggerUp() == true)
            {
                fixedJoint.connectedBody.velocity = device.velocity;
                Destroy(fixedJoint);
                nearestObject = null;
                nearestObjectDistance = 1000;
            }
        }
        else if (fixedJoint == null)
        {
            if (nearestObject != null)
            {
                if (device.GetHairTriggerDown() == true)
                {
                    fixedJoint = gameObject.AddComponent<FixedJoint>();

                    fixedJoint.connectedBody = nearestObject.GetComponent<Rigidbody>();

                    if (fixedJoint.connectedBody == null)
                    {
                        fixedJoint.connectedBody = nearestObject.GetComponentInParent<Rigidbody>();
                    }

                    if (fixedJoint.connectedBody == null)
                    {
                        Destroy(fixedJoint);
                        return;
                    }

                    fixedJoint.breakForce = 1000;

                    //reset shader
                    nearestObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f);
                }
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (fixedJoint == null)
        {
            if (col.gameObject != nearestObject)
            {
                if (nearestObject == null)
                {
                    nearestObject = col.gameObject;

                    nearestObjectDistance = (gameObject.transform.position - col.gameObject.transform.position).magnitude;

                    //change outline width
                    nearestObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.004f);
                }
                else
                {
                    float distance = (gameObject.transform.position - col.gameObject.transform.position).magnitude;
                    if (distance < nearestObjectDistance)
                    {
                        //reset outline width
                        nearestObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f);

                        nearestObject = col.gameObject;

                        nearestObjectDistance = distance;

                        //change outline width
                        nearestObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.004f);
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (fixedJoint == null)
        {
            if (other.gameObject == nearestObject)
            {
                //reset outline width
                nearestObject.GetComponent<Renderer>().material.SetFloat("_Outline", 0.0f);

                nearestObject = null;

                nearestObjectDistance = 1000;
            }
        }
    }

    void OnJointBreak(float force)
    {
        fixedJoint.connectedBody.velocity = device.velocity;
    }

    void OnTriggerEnter(Collider other)
    {
        //checks to see if the hand has hit the stove
        if (other.tag == "StoveKnob")
        {
            //sets the heating area
            other.GetComponent<StoveKnob>().SetActive();
            Debug.Log("hit stoveK");
        }

        if (other.tag == "Finish")
        {
            other.GetComponent<Bell>().SetDone(true);
            Debug.Log("hit bell");
        }
    }
}