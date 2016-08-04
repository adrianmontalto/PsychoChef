using UnityEngine;
using System.Collections;

public class HeatingArea : MonoBehaviour
{
    public float heatRate = 0.0f;//the rate  at which the area heats up
    public float cooldownRate = 0.0f;//the rate at which the area cools down
    public float maxTemperature = 0.0f;//the maximum temperature that the area can get to
    private float temperature = 1.0f;//the temperature of the area
    private bool isHeating = false;//determine whether the area is heating up

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if the area is heating up
        if (isHeating == true)
        {
            if(temperature < maxTemperature)
            {
                //increase the areas temperature
                temperature += heatRate * Time.deltaTime;
            }
            if(temperature > maxTemperature)
            {
                temperature = maxTemperature;
            }
        }

        //checks to see if the area isnt heating up
        if (isHeating == false)
        {
            //checks to see that the temperature is greater then zero
            if (temperature > 0.0f)
            {
                //reduces the areas temperature
                temperature -= cooldownRate * Time.deltaTime;
            }

            //checks to see if the temperature of the area is less then zero
            if (temperature < 0.0f)
            {
                //sets the temperature to zero
                temperature = 0.0f;
            }
        }
    }

    public void SetHeating(bool heat)
    {
        isHeating = heat;
    }

    void OnTriggerEnter(Collider other)
    {
        if(isHeating)
        {
            //checks to see if the saucepan has collided
            if (other.tag == "SaucePan")
            {
                //sets the boiling area in the saucepoan to true
                other.GetComponent<Saucepan>().SetBoilAreaActive(true);
                //boil.SetBoiling(true);
            }

            //checks to see if food is in the heating area
            if (other.tag == "Food")
            {

                //sets the food to be cooking at the temperature of the food
                other.GetComponent<Food>().SetCooking(true, temperature);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (isHeating)
        {
            //checks to see if the saucepan has collided
            if (other.tag == "SaucePan")
            {
                //sets the boiling area in the saucepoan to true
                other.GetComponent<Saucepan>().SetBoilAreaActive(true);
                //boil.SetBoiling(true);
            }

            //checks to see if food is in the heating area
            if (other.tag == "Food")
            {

                //sets the food to be cooking at the temperature of the food
                other.GetComponent<Food>().SetCooking(true, temperature);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        //checks to see if the food has left the heating area
        if (other.tag == "SaucePan")
        {
            //sets the boiling to be false
            other.GetComponent<Saucepan>().SetBoilAreaActive(false);
        }

        //checks to see if the food has left the heating area
        if (other.tag == "Food")
        {
            Debug.Log("food exit");
            //sets the cooking of food to be false
            other.GetComponent<Food>().SetCooking(false, 1.0f);
        }
    }
}

