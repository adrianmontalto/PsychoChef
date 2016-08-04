using UnityEngine;
using System.Collections;

public class StoveKnob : MonoBehaviour
{
    public HeatingArea heatArea;
    private bool isActive = false;
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision col)
    {
        //check to see if the hand has hit the object
        if (col.gameObject.tag == "Hand")
        {
            Debug.Log("stoveoff");
            //checks to see if the knob is on
            if(isActive == true)
            {
                //turns the knob off
                isActive = false;
                //turns the heat area off
                heatArea.SetHeating(false);
                //disables the heat areas mesh
                heatArea.GetComponent<MeshRenderer>().enabled = false;
                return;
            }

            //checks to see if the stove knob isnt active
            if(isActive == false)
            {
                Debug.Log("stove on");
                //sets the knob to active
                isActive = true;
                //turns the heat area on
                heatArea.SetHeating(true);
                //enables the heat areas mesh
                heatArea.GetComponent<MeshRenderer>().enabled = true;
                return;
            }
        }
    }
}
