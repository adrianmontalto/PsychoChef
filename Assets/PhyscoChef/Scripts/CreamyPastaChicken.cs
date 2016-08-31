using UnityEngine;
using System.Collections;

public class CreamyPastaChicken : MonoBehaviour
{
    public FoodMissions missions;//the mission manager
    public FoodIngredientArea ingredientsArea;//the ingredient area
    public Bell bell;//the food done bell
    public float increaseRate = 0.0f;//the rate at which satisfaction increases
    public float decreaseRate = 0.0f;//the rate at which satisfaction decreases
    public int chickenSlices = 0;//the amount of chicken slices required
    private bool isActive = false;//whether the area is active
    private bool pastaBoiled = false;//sets whether the pasta is boiled
    private bool chickenSliced = false;//sets whether the chicken is sliced
    private bool creamAdded = false;//sets whether the cream has been added
    private bool oilCooked = false;//sets whether the oil is cooked
    private float satisfactionIncrease = 0.0f;//the amount satisfaction is increased
    private float satisfactionDecrease = 0.0f;//the amount of satisfaction decreased
    private float totalSatisfaction = 0.0f;//the total amount of satisfaction
    private float timeRemaining = 0.0f;//the amount of time left
    private float timeUsed = 0.0f;//the amount of time used
    private int correctIngredients = 1;//the amount of correct ingredients
    private int incorrectIngredients = 1;//the amount of incorrect ingredients
    private int numberOfChickenSlices = 0;//the amount of cooked sliced chicken
    private int totalCookedChicken = 0;//the total amount of cooked chicken
    private int totalCookedOil = 0;//the total amount of cooked oil
    private int totalCreamAdded = 0;//the total amount of cream
    private int totalBoiledPasta = 0;//the total amount of boiled pasta


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //checks to see if the recipe is active
	    if(isActive)
        {
            //calculates the satisfaction increase
            satisfactionIncrease = missions.GetComponent<FoodMissions>().GetTimeLeft() * correctIngredients * increaseRate;
            //calculates the satisfaction decrease
            satisfactionDecrease = missions.GetComponent<FoodMissions>().GetTimeUsed() * incorrectIngredients * decreaseRate;
            //calculate the total amount of satisfaction given
            totalSatisfaction = satisfactionIncrease + satisfactionDecrease;
            //applies the satisfaction to the missions satisfaction
            missions.satisfaction += totalSatisfaction;
            //resets all of the objects
            Reset();
        }
	}

    public void SetActive(bool active)
    {
        isActive = active;
    }

    void OnTriggerEnter(Collider other)
    {
        //checks to see if food has landed in the recipe area
        if(other.tag == "Food")
        {
            //checks to see if the food is pasta
            if (other.GetComponent<Food>().foodName == FoodName.PASTA)
            {
                //checks that the pasta is in the correct state
                CheckPasta(other);
            }

            //checks to see if the food is chicken
            if (other.GetComponent<Food>().foodName == FoodName.CHICKEN)
            {
                //checks that there is the correct chicken
                CheckChicken(other);
            }

            //checks to see if the food is oil
            if (other.GetComponent<Food>().foodName == FoodName.OIL)
            {
                //checks if the oil is in the correct state
                CheckOil(other);
            }

            //checks to see if the food is cream
            if (other.GetComponent<Food>().foodName == FoodName.CREAM)
            {
                //checks to see if the cream is in the correct state
                CheckCream();
            }
            else
            {
                //increases the number of incorrect ingredients by one
                incorrectIngredients ++;
            }               
        }
        //checks to see if it is not food
        if(other.tag != "Food")
        {
            //increases the number of incorrect ingredients by one
            incorrectIngredients++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //checks to see iof food is being removed
        if(other.tag == "Food")
        {
            //checks to see if the food is pasta
            if(other.GetComponent<Food>().foodName == FoodName.PASTA)
            {
                //controls the removal of the pasta
                RemovePasta(other);
            }

            //checks to see if the food is chicken
            if (other.GetComponent<Food>().foodName == FoodName.CHICKEN)
            {
                //controls the removal of the chicken
                RemoveChicken(other);
            }

            //checks to see if the food is cream
            if (other.GetComponent<Food>().foodName == FoodName.CREAM)
            {
                //controls the removal of cream
                RemoveCream();
            }

            //checks to see if the food is oil
            if (other.GetComponent<Food>().foodName == FoodName.OIL)
            {
                //controls the removal of oil
                RemoveOil(other);
            }

            else
            {
                //increase the incorrect ingredients by one
                incorrectIngredients --;
            }
        }
        else
        {
            //increases the correct ingredients by one
            incorrectIngredients --;
        }
    }

    void CheckPasta(Collider col)
    {
        //checks to see if the pasta is boiled
        if(pastaBoiled)
        {
            //increases the incorrect ingredients by one
            incorrectIngredients++;
            //checks to see if the pasta is boiled
            if(col.GetComponent<Food>().GetBoiled())
            {
                //increase the amount of boiled pasta by one
                totalBoiledPasta ++;
            }
        }
        else
        {
            //checks to see if the pasta is boiled
            if (col.GetComponent<Food>().GetBoiled() == true)
            {
                //increase the correct ingredients by one
                correctIngredients++;
                //increase the total amount of boiled pasta by one
                totalBoiledPasta ++;
                //sets the boiled pasta to true
                pastaBoiled = true;
            }
            //checks to see if the pasta isnt boiled
            if(col.GetComponent<Food>().GetBoiled() == false)
            {
                //increase the boiled pasta amount by one
                incorrectIngredients ++;
            }
        }
    }
    
    void RemovePasta(Collider col)
    {
        //checks if pasta has been boiled
        if(pastaBoiled)
        {
            if(col.GetComponent<Food>().GetBoiled())
            {
                //decrease the correct ingredients by one
                correctIngredients--;

                //checks to see that the amount of boiled pasta is greater then one
                if (totalBoiledPasta > 0)
                {
                    //reduce the amount of boiled pasta by one
                    totalBoiledPasta--;
                    //checks to see that the amount of boiled pasta is greater then one
                    if (totalBoiledPasta > 0)
                    {
                        //increase the correct ingredients by one
                        correctIngredients++;
                        //decrease the incorrect ingredients by one
                        incorrectIngredients--;
                        //sets the pasta boiled to true
                        pastaBoiled = true;
                    }
                }
            }
            else
            {
                //reduce the amount of incorrect ingredients by one
                incorrectIngredients --;
            }
        }
        else
        {
            //decrease the incorrect ingredients by one
            incorrectIngredients--;
        }
    }

    void CheckChicken(Collider col)
    {
        //checks to see if the chicken is sliced
        if(chickenSliced)
        {
            //increase the amount of correct ingredients by one
            incorrectIngredients++;
            //checks to see if the chicken is cooked
            if (col.GetComponent<Food>().GetCooked() == true)
            {
                //checks to see if the chicken is sliced
                if (col.GetComponent<Food>().GetSliced() == true)
                {
                    //increase the number of slice by one
                    numberOfChickenSlices++;
                    //checks to see if the number of slices is the same as the required amount needed
                    if (numberOfChickenSlices == chickenSlices)
                    {
                        //increase total cooked chicken by one
                        totalCookedChicken++;
                        //stes the number of slices to zero
                        numberOfChickenSlices = 0;   
                    }
                }
            }
        }
        else
        {
            //checks to see if the chicken is cooked
            if(col.GetComponent<Food>().GetCooked() == true)
            {
                //checks to see if the chicken is sliced
                if(col.GetComponent<Food>().GetSliced() == true)
                {
                    //increase the number of slices by one
                    numberOfChickenSlices++;
                    //checks to see if the number of slices is the same as the required amount
                    if(numberOfChickenSlices == chickenSlices)
                    {
                        //increase the total cooked chicken by one
                        totalCookedChicken ++;
                        //sets the chicken sliced to true
                        chickenSliced = true;
                        //sets the number of slices to zero
                        numberOfChickenSlices = 0;
                    }
                }
                else
                {
                    //increase the incorect ingredients by one
                    incorrectIngredients ++;
                }
            }
            else
            {
                //increase the correct ingredients by one
                incorrectIngredients ++;
            }
        }
    }

    void RemoveChicken(Collider col)
    {
        //checks if the chicken is sliced
        if(chickenSliced)
        {
            if (col.GetComponent<Food>().GetSliced())
            {
                if(col.GetComponent<Food>().GetBoiled())
                {
                    //reduce the incorrect ingredients by one
                    correctIngredients--;
                    //checks to see if the total cooked chicken is greater then zero
                    if (totalCookedChicken > 0)
                    {
                        //reduce the total amount of cooked chicken by one
                        totalCookedChicken--;
                        //checks to see if the total cooked chicken is greater then zero
                        if (totalCookedChicken > 0)
                        {
                            //increase the correct ingredients by one
                            correctIngredients++;
                            //reduce the incorrect ingredients by one
                            incorrectIngredients--;
                            //sets the chicken to be sliced
                            chickenSliced = true;
                        }
                    }
                }
                else
                {
                    //reduces the incorrect ingredients by one
                    incorrectIngredients--;
                }
            }
            else
            {
                //reduces the incorrect ingredients by one
                incorrectIngredients--;
            }          
        }
        else
        {
            //reduce the incorrect ingredients by one
            incorrectIngredients --;
        }
    }

    void CheckOil(Collider col)
    {
        //checks to see if the oil is cooked
        if(oilCooked)
        {
            //increase the incorrect ingredients by one
            incorrectIngredients ++;
            //checks to see if the oil is cooked
            if (col.GetComponent<Food>().GetCooked() == true)
            {
                //increase the total cooked oil by one
                totalCookedOil ++;
            }
        }
        else
        {
            //checks to see if the oil is cooked
            if(col.GetComponent<Food>().GetCooked() == true)
            {
                //increase the correct ingredients by one
                correctIngredients ++;
                //increase the total cooked oil by one
                totalCookedOil ++;
                //sets the oil cooked to true
                oilCooked = true;
            }
            //checks to see that the oil isn't cooked
            if(col.GetComponent<Food>().GetCooked() == false)
            {
                //increase the incorrect ingredients by one
                incorrectIngredients ++;
            }
        }        
    }

    void RemoveOil(Collider col)
    {
        //checks to see if oil is cooked
        if(oilCooked)
        {
            if(col.GetComponent<Food>().GetCooked())
            {
                //reduce the correct ingredients by one
                correctIngredients--;
                //checks to see it the total cooked oil is greater then zero
                if (totalCookedOil > 0)
                {
                    //reduce the total cooked oil by one
                    totalCookedOil--;
                    //checks to see it the total cooked oil is greater then zero
                    if (totalCookedOil > 0)
                    {
                        //increase the amount of correct ingredients by one
                        correctIngredients++;
                        //reduce the amount of incorrect ingredients by one
                        incorrectIngredients--;
                        //sets the oil cooked to true
                        oilCooked = true;
                    }
                }
            }
            else
            {
                //reduce the incorrect ingredients by one
                incorrectIngredients --;
            }
        }
        else
        {
            //reduce the incorrect ingredients by one
            incorrectIngredients --;
        }
    }

    void CheckCream()
    {
        //checks to see if cream is added
        if(creamAdded)
        {
            //increases the incorrect ingredients by one
            incorrectIngredients++;
        }
        else
        {
            //increase the correct ingredients by one
            correctIngredients ++;
            //sets the cream added to true
            creamAdded = true;
        }
    }

    void RemoveCream()
    {
        //checks to see if cream is added
        if(creamAdded)
        {
            //reduce the correct ingredients by one
            correctIngredients --;
            //checks to see if the total cream added is greater then one
            if(totalCreamAdded > 0)
            { 
                //reduce the total cream added by one
                totalCreamAdded--;
                //checks to see if the total cream added is greater then one
                if (totalCreamAdded > 0)
                {
                    //increase the correct ingredients by one
                    correctIngredients ++;
                    //decrease the incorrect ingredients by one
                    incorrectIngredients --;
                    //sets the cream added to true
                    creamAdded = true;
                }
            }
        }
        else
        {
            //decrease the incorrect ingredients by one
            incorrectIngredients --;
        }
    }
    void Reset()
    {
        chickenSlices = 0;
        pastaBoiled = false;
        chickenSliced = false;
        creamAdded = false;
        oilCooked = false;
        satisfactionIncrease = 0.0f;
        satisfactionDecrease = 0.0f;
        totalSatisfaction = 0.0f;
        timeRemaining = 0.0f;
        timeUsed = 0.0f;
        correctIngredients = 0;
        incorrectIngredients = 0;
        numberOfChickenSlices = 0;
        totalCookedChicken = 0;
        totalCookedOil = 0;
        totalCreamAdded = 0;
        totalBoiledPasta = 0;
        missions.SetChecking(false);
        missions.ResetTimer();
        ingredientsArea.SetActive(false);
        bell.GetComponent<Bell>().SetDone(false);
        isActive = false;

        Rigidbody[] bodies = FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
        foreach (Rigidbody body in bodies)
        {
            if(body.GetComponent<Items>() != null)
            {
                body.GetComponent<Items>().ResetPostion();
            }           
        }
    }
}
