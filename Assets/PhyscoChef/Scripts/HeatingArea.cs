using UnityEngine;
using System.Collections;

public class HeatingArea : MonoBehaviour
{
    private float temperature;
    private float heatRate;
    private bool isHeating;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isHeating == true)
        {

        }
	}

    public void Heating(bool heating,float rate,float temp)
    {
        isHeating = heating;
        heatRate = rate;
        temperature = temp;
    }
}
