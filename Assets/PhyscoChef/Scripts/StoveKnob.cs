using UnityEngine;
using System.Collections;

public class StoveKnob : MonoBehaviour
{
    public StoveFire heatArea;
    private bool isActive = false;

    public FireEmiter fireEmiter;

    public float rotation;
    private float maxRotation = 180;

	// Use this for initialization
	void Start ()
    {
        rotation = transform.rotation.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float currRotation = transform.rotation.eulerAngles.z;

        if (currRotation != rotation)
        {

            float percent = currRotation / maxRotation;

            if (isActive == true && currRotation == 0)
            {
                isActive = false;
                fireEmiter.ChangeEmit(false);
            }
            else if (isActive == false && currRotation != 0)
            {
                isActive = true;
                fireEmiter.ChangeSizeNSpeed(percent);
                fireEmiter.ChangeEmit(true);
            }
            else
            {
                fireEmiter.ChangeSizeNSpeed(percent);
            }
        }

        rotation = currRotation;
	}

    public void SetActive()
    {
        if (isActive == true)
        {
            //turns the knob off
            isActive = false;
            //turns the heat area off
            heatArea.SetHeating(false);
            //Turn off fire particles
            fireEmiter.ChangeEmit(false);

            return;
        }

        //checks to see if the stove knob isnt active
        if (isActive == false)
        {
            //sets the knob to active
            isActive = true;
            //turns the heat area on
            heatArea.SetHeating(true);
            //Turn on fire particles
            fireEmiter.ChangeEmit(true);

            return;
        }
    }
}
