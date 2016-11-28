using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

    private List<FixedJoint> dials;
    private List<HingeJoint> doorJoints;

    //need list of chopping board and baking tray
    private ParadeHandler parade;

    //monitor object
    //stove manager
    //list of table
    //hands

    private float timeSection;
    private float countdown;

    // Use this for initialization
    void Start()
    {
        parade = FindObjectOfType<ParadeHandler>();

        FixedJoint[] fixedJoints = FindObjectsOfType<FixedJoint>();

        dials = new List<FixedJoint>();

        for (int i = 0; i < fixedJoints.Length; i++)
        {
            if (fixedJoints[i].name.Contains("Dial") && fixedJoints[i].name != "Dials")
            {
                dials.Add(fixedJoints[i]);
            }
        }

        HingeJoint[] hinges = FindObjectsOfType<HingeJoint>();

        doorJoints = new List<HingeJoint>();

        for (int i = 0; i < hinges.Length; i++)
        {
            if (hinges[i].name.Contains("Door"))
            {
                doorJoints.Add(hinges[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {

        }
    }
}
