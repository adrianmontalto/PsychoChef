using UnityEngine;
using System.Collections;

public class BoilingArea : MonoBehaviour
{
    public float maxTemperature = 0.0f;
    public float partialyBoiled = 0.0f;
    public float heatRate = 0.0f;
    public float cooldownRate = 0.0f;
    public Material notBoiledMaterial;
    public Material partiallyBoiledMaterial;
    public Material fullyBoiledmaterial;
    private float temperature = 1.0f;
    private bool isBoiling;
   
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isBoiling == true)
        {
            if(temperature < maxTemperature)
            {
                temperature += heatRate * Time.deltaTime;
            }
            else
            {
                temperature = maxTemperature;
            }
        }
        if(isBoiling == false)
        {
            if(temperature > 0)
            {
                temperature -= cooldownRate * Time.deltaTime;
            }
            if(temperature < 0)
            {
                temperature = 0.0f;
            }
        }
        CheckBoilingStage();
	}

    public void SetBoiling(bool boil)
    {
        isBoiling = boil;
    }

    void CheckBoilingStage()
    {
        if(temperature < partialyBoiled)
        {
            this.GetComponent<MeshRenderer>().material = notBoiledMaterial;
        }

        if(temperature >= partialyBoiled)
        {
            if(temperature < maxTemperature)
            {
                this.GetComponent<MeshRenderer>().material = partiallyBoiledMaterial;
            }
        }

        if(temperature == maxTemperature)
        {
            this.GetComponent<MeshRenderer>().material = fullyBoiledmaterial;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //checks to see if a food is in the water
        if (other.tag == "Food")
        {
            //sets the food to boiling
            other.GetComponent<Food>().SetBoiling(true,temperature);
        }
    }

    void OnTriggerStay(Collider other)
    {
        //checks to see if a food is in the water
        if (other.tag == "Food")
        {
            //sets the food to boiling
            other.GetComponent<Food>().SetBoiling(true, temperature);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Food")
        {
            //sets the food to not cooking
            other.GetComponent<Food>().SetBoiling(false,1.0f);
        }
    }
}
