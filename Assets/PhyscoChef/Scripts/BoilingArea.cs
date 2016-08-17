using UnityEngine;
using System.Collections;

public class BoilingArea : MonoBehaviour
{
    public float maxTemperature = 0.0f;//the max temperature of the water
    public float partialyBoiled = 0.0f;//the temperature at which the water is partially boiled
    public float heatRate = 0.0f;//the rate at which the water heats up
    public float cooldownRate = 0.0f;//the rate at which the water cools
    public Material notBoiledMaterial;//the texture for not boiled
    public Material partiallyBoiledMaterial;//the texture for the partially biled temperature
    public Material fullyBoiledMaterial;//the texture for when the water is completly boiled
    private float temperature = 1.0f;//the temperature of the water
    private bool isBoiling;//whether the water is boiling
   
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //checks to see if the water is boiling
	    if(isBoiling == true)
        {
            Debug.Log("ba");
            //checks that the temperature is less then the max temperature
            if(temperature < maxTemperature)
            {
                //increase the temperature of the water
                temperature += heatRate * Time.deltaTime;
            }
            //checks to see if the waters temperature is greater than or equal to the max temperature
            if(temperature >= maxTemperature)
            {
                //sets the temperature to the max temperature
                temperature = maxTemperature;
            }
        }

        //checks to see if the water isn't boiling
        if(isBoiling == false)
        {
            //checks to see if the temperature is greater then zero
            if(temperature > 0)
            {
                //reduces the temperature
                temperature -= cooldownRate * Time.deltaTime;
            }
            //checks to see if the temperature is less then zero
            if(temperature < 0)
            {
                //sets the tempeature to zero
                temperature = 0.0f;
            }
        }
        //checks for which stage of boiling the water is in
        CheckBoilingStage();
	}

    public void SetBoiling(bool boil)
    {
        isBoiling = boil;
    }

    void CheckBoilingStage()
    {
        //checks to see if the water temp is less then the partially boiled temperature
        if(temperature < partialyBoiled)
        {
            //sets the boil texture to the not boiled material
            this.GetComponent<MeshRenderer>().material = notBoiledMaterial;
        }

        //checks to see if the temperature is greater then or equal to 
        //the partially boiled state
        if(temperature >= partialyBoiled)
        {
            //checks to see if the temperature is less then the max temperature
            if(temperature < maxTemperature)
            {
                //sets the texture to the partially boiled texture
                this.GetComponent<MeshRenderer>().material = partiallyBoiledMaterial;
            }
        }

        //checks to see if the temperature is equal to the max temperature
        if(temperature == maxTemperature)
        {
            //sets the texture to the fully boiled texture
            this.GetComponent<MeshRenderer>().material = fullyBoiledMaterial;
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
