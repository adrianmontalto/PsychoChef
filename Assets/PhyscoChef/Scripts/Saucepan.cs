using UnityEngine;
using System.Collections;

public class Saucepan : MonoBehaviour
{
    public BoilingArea boilingArea;//the area of the pot for boiling water
    public float heatRate = 0.0f;//the rate at which the saucepan heats up
    public float cooldownRate = 0.0f;//the rate at which the saucepan cools down
    public float maxTemperature = 0.0f;//the max temperature that the saucepan can reach
//    private float temperature = 0.0f;//the temperature of ther saucepan
    private bool isBoiling = false;//whether the saucepan is on a heating area

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        //checks to see the area is boilig
	    if(isBoiling == true)
        {
            //sets the boiling area to boiling
            boilingArea.SetBoiling(true);
        }
        //
        ////checks to see if the sauce is not boiling
        if(isBoiling == false)
        {
            //sets the boiling area to not boiling
            boilingArea.SetBoiling(false);
        }
	}

    public void SetBoilAreaActive(bool boil)
    {
        //Debug.Log("boil active");
        boilingArea.SetBoiling(boil);
    }

    public bool GetBoilActive()
    {
        return boilingArea.GetBoiling();
    }
}
