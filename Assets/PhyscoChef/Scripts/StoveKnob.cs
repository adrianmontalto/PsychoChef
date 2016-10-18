using UnityEngine;
using System.Collections;

public class StoveKnob : MonoBehaviour
{
    public StoveFire heatArea;
    private bool isActive = false;

    public FireEmiter fireEmiter;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SetActive()
    {
        if (isActive == true)
        {
            Debug.Log("stove on");
            //turns the knob off
            isActive = false;
            //turns the heat area off
            heatArea.SetHeating(false);
            //disables the heat areas mesh

            //Turn off fire particles
            fireEmiter.ChangeEmit(false);

            return;
        }

        //checks to see if the stove knob isnt active
        if (isActive == false)
        {
            Debug.Log("stove off");
            //sets the knob to active
            isActive = true;
            //turns the heat area on
            heatArea.SetHeating(true);
            //enables the heat areas mesh

            //Turn on fire particles
            fireEmiter.ChangeEmit(true);

            return;
        }
    }
}
