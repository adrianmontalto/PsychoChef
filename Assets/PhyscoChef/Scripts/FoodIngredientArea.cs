using UnityEngine;
using System.Collections;

public class FoodIngredientArea : MonoBehaviour
{
    public CreamyPastaChicken chickenPasta;
    private bool isActive = false;
    public FoodMissions mission;
    private int orderNumber = 0;
	// Use this for initialization
	void Start ()
    {
        //sets the order number to the missions order number
        orderNumber = mission.GetComponent<FoodMissions>().GetOrderNumber();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isActive)
        {
            //sets the mission to be checking
            mission.GetComponent<FoodMissions>().SetChecking(true);
            //checks to see if the recipe number is recipe one
            if(orderNumber == 1)
            {
                //sets the creamy chicken pasta to active
                chickenPasta.SetActive(true);
            }
        }
	}

    public void SetActive(bool active)
    {
        //sets the active value
        isActive = active;
    }
}
