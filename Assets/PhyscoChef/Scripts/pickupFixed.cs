using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class pickupFixed : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    FixedJoint fixedJoint;

    Rigidbody rb;

    GameObject nearestObject;

    float nearestObjectDistance;

    public Shader outline;
    public Shader standard;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
                    nearestObject.GetComponent<Renderer>().material.shader = standard;
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
                Debug.LogWarning("NOTSAME");
                if (nearestObject == null)
                {
                    Debug.LogWarning("NEWCOL");
                    nearestObject = col.gameObject;

                    nearestObjectDistance = (gameObject.transform.position - col.gameObject.transform.position).magnitude;

                    //change shader
                    nearestObject.GetComponent<Renderer>().material.shader = outline;
                }
                else
                {
                    Debug.LogWarning("OLDCOL");
                    float distance = (gameObject.transform.position - col.gameObject.transform.position).magnitude;
                    if (distance < nearestObjectDistance)
                    {
                        Debug.LogWarning("CLOSERCOL");
                        //reset shader
                        nearestObject.GetComponent<Renderer>().material.shader = standard;

                        nearestObject = col.gameObject;

                        nearestObjectDistance = distance;

                        //change shader
                        nearestObject.GetComponent<Renderer>().material.shader = outline;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.LogWarning("WHAT");
        if (other.gameObject == nearestObject)
        {
            Debug.LogWarning("YES");

            nearestObject.GetComponent<Renderer>().material.shader = standard;

            nearestObject = null;
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