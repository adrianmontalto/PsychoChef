using UnityEngine;
using System.Collections;

public class Boiling : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //checks to see if a food is in the water
        if(other.tag == "Food")
        {
           //sets the food to cooking
           //other.GetComponent<Food>().SetCooking(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Food")
        {
            //sets the food to not cooking
            //other.GetComponent<Food>().SetCooking(false);
        }
    }
}
