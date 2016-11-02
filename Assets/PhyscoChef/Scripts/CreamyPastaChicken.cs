using UnityEngine;
using System.Collections;

public class CreamyPastaChicken : MonoBehaviour
{
    [SerializeField]
    private FoodMissions missions;//the mission manager
    [SerializeField]
    private FoodIngredientArea ingredientsArea;//the ingredient area
    [SerializeField]
    private Bell bell;//the food done bell
    [SerializeField]
    private int chickenSlices = 0;//the amount of chicken slices required
    private bool isActive = false;//whether the area is active
    private bool pastaBoiled = false;//sets whether the pasta is boiled
    private bool pastaOverBoiled = false;
    private bool chickenSliced = false;//sets whether the chicken is sliced
    private bool creamAdded = false;//sets whether the cream has been added
    private bool oilAdded = false;//sets whether the oil is cooked
    private bool incompleteCookedChicken = false;//used to determine if an unperfect chicken is present
    private float correctIngredients = 1;//the amount of correct ingredients
    private float incorrectIngredients = 1;//the amount of incorrect ingredients
    private int numberOfChickenSlices = 0;//the amount of cooked sliced chicken
    private int numberOfCookedChickenSlices = 0;//the amount of cooked slices
    private int numberOfOvercookedSlices = 0;//the amount of overcooked slices
    private int totalOil = 0;//the total amount of cooked oil
    private int totalCreamAdded = 0;//the total amount of cream
    private int totalBoiledPasta = 0;//the total amount of boiled pasta
    private int totalOverBoiledPasta = 0;//the total amount of overboiled pasta
    private int numberOfIngredients = 4;//the number of ingredients required to complete the recipe

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
            missions.AddSatisfaction(numberOfIngredients, correctIngredients, incorrectIngredients);
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
            if (other.GetComponent<Food>().GetName() == FoodName.PASTA)
            {
                //checks that the pasta is in the correct state
                CheckPasta(other);
            }

            else
            {
                //increases the number of incorrect ingredients by one
                incorrectIngredients ++;
            }               
        }

        if(other.tag == "Oil")
        {
            CheckOil();
        }

        if(other.tag == "Cream")
        {
            CheckCream();
        }

        //checks to see if it is not food
        else
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
            if(other.GetComponent<Food>().GetName() == FoodName.PASTA)
            {
                //controls the removal of the pasta
                RemovePasta(other);
            }

            //checks to see if the food is chicken
            if (other.GetComponent<Food>().GetName() == FoodName.CHICKEN)
            {
                //controls the removal of the chicken
                RemoveChicken(other);
            }

            else
            {
                //increase the incorrect ingredients by one
                incorrectIngredients --;
            }
        }

        if (other.tag == "Oil")
        {
            RemoveOil();
        }

        if (other.tag == "Cream")
        {
            RemoveCream();
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
            
            if (totalOverBoiledPasta > 0 && totalBoiledPasta < 1)
            {
                if (col.GetComponent<Food>().GetBoiled())
                {
                    correctIngredients += 0.5f;
                    totalBoiledPasta ++;
                }
            }
            else
            {
                //checks to see if the pasta is boiled
                if (col.GetComponent<Food>().GetBoiled())
                {
                    //increase the amount of boiled pasta by one
                    totalBoiledPasta++;
                }
                //checks to see if the pasta is overboiled
                if (col.GetComponent<Food>().GetOverBoiled())
                {
                    //increase the amount of over boiled pasta by one
                    totalOverBoiledPasta++;
                }
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
            //checks to see if the pasta is overboiled
            if(col.GetComponent<Food>().GetOverBoiled() == true)
            {
                //increase the correct ingredients by half
                correctIngredients += 0.5f;
                //increase the total amount of overboiled pasta by one
                totalOverBoiledPasta ++;
                //sets the pasta boiled to true
                pastaOverBoiled = true;
            }

            //checks to see if the pasta isnt boiled
            else
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
            if(col.GetComponent<Food>().GetOverBoiled() == true)
            {
                //decrease the correct ingredients by one
                correctIngredients--;

                //checks to see that the amount of boiled pasta is greater then one
                if (totalOverBoiledPasta > 0)
                {
                    //reduce the amount of boiled pasta by one
                    totalBoiledPasta--;
                    //checks to see that the amount of boiled pasta is greater then zero
                    if (totalOverBoiledPasta > 0)
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
        //checks if a complete cooked chicken has been added
        if(chickenSliced)
        {
            //checks if the chicken piece is sliced
            if(col.GetComponent<Food>().GetSliced())
            {
                incorrectIngredients ++;
                //checks if the chicken is cooked
                if(col.GetComponent<Food>().GetCooked())
                {
                    numberOfCookedChickenSlices ++;
                }
                //checks if the chicken is overcooked
                if(col.GetComponent<Food>().GetOverCooked())
                {
                    numberOfOvercookedSlices ++;
                }
            }
            else
            {
                incorrectIngredients ++;
            }
        }
        else
        {
            //checks if the chicken has been cut
            if (col.GetComponent<Food>().GetSliced())
            {
                //checks if the chicken is cooked
                if (col.GetComponent<Food>().GetCooked())
                {
                    numberOfCookedChickenSlices++;
                    numberOfChickenSlices++;
                    //checks to see if there is the correct amount of chicken slices
                    if (numberOfChickenSlices == chickenSlices)
                    {
                        chickenSliced = true;
                        //checks to see if there are any over cooked chicken pieces
                        if (numberOfOvercookedSlices > 0)
                        {
                            correctIngredients += 0.5f;
                            incompleteCookedChicken = true;
                        }
                        else
                        {
                            correctIngredients ++;
                        }
                    }
                }
                //checks to see if the chicken is overcooked
                if (col.GetComponent<Food>().GetOverCooked())
                {
                    numberOfOvercookedSlices++;
                    numberOfChickenSlices++;
                    //checks to see that there are the correct amount of chicken pieces
                    if (numberOfChickenSlices == chickenSlices)
                    {
                        chickenSliced = true;
                        correctIngredients += 0.5f;
                        incompleteCookedChicken = true;
                    }
                }
                else
                {
                    incorrectIngredients++;
                }
            }
        }
    }

    void RemoveChicken(Collider col)
    {
        //checks to see if a whole chicken is added
        if(chickenSliced)
        {
            //checks to see if the chicken is cut
            if(col.GetComponent<Food>().GetSliced())
            {
                //checks to see if the chicken is cooked
                if(col.GetComponent<Food>().GetCooked())
                {
                    numberOfChickenSlices --;
                    numberOfCookedChickenSlices --;
                    if(numberOfChickenSlices < chickenSlices)
                    {
                        chickenSliced = false;
                        if(incompleteCookedChicken)
                        {
                            correctIngredients -= 0.5f;
                        }
                        else
                        {
                            correctIngredients --;
                        }
                    }
                }

                //checks to see if the chicken is overcooked
                if(col.GetComponent<Food>().GetOverCooked())
                {
                    numberOfChickenSlices --;
                    numberOfOvercookedSlices--;
                    if(numberOfChickenSlices >= chickenSlices)
                    {
                        if(incompleteCookedChicken)
                        {
                            if(numberOfOvercookedSlices < 1)
                            {
                                incompleteCookedChicken = false;
                                correctIngredients += 0.5f;
                            }
                        }
                    }
                    else
                    {
                        chickenSliced = false;
                        if(incompleteCookedChicken)
                        {
                            correctIngredients -= 0.5f;
                        }
                        else
                        {
                            correctIngredients --;
                        }
                    }
                }
                else
                {
                    incorrectIngredients --;
                }
            }
            else
            {
                incorrectIngredients --;
            }
        }

        else
        {
            incorrectIngredients --;
        }
    }

    void CheckOil()
    {
        if (!oilAdded)
        {
            correctIngredients++;
            totalOil++;
            oilAdded = true;
        }
        else
        {
            incorrectIngredients++;
            totalOil++;
        }
    }

    void RemoveOil()
    {
        if (totalOil > 1)
        {
            totalOil--;
            incorrectIngredients--;
        }
        else
        {
            correctIngredients--;
            totalOil--;
            oilAdded = false;
        }
    }

    void CheckCream()
    {
        //checks to see if cream is added
        if (creamAdded)
        {
            //increases the incorrect ingredients by one
            incorrectIngredients++;
        }
        else
        {
            //increase the correct ingredients by one
            correctIngredients++;
            //sets the cream added to true
            creamAdded = true;
        }
    }

    void RemoveCream()
    {
        //checks to see if cream is added
        if (creamAdded)
        {
            //reduce the correct ingredients by one
            correctIngredients--;
            //checks to see if the total cream added is greater then one
            if (totalCreamAdded > 0)
            {
                //reduce the total cream added by one
                totalCreamAdded--;
                //checks to see if the total cream added is greater then one
                if (totalCreamAdded > 0)
                {
                    //increase the correct ingredients by one
                    correctIngredients++;
                    //decrease the incorrect ingredients by one
                    incorrectIngredients--;
                    //sets the cream added to true
                    creamAdded = true;
                }
            }
        }
        else
        {
            //decrease the incorrect ingredients by one
            incorrectIngredients--;
        }
    }

    void Reset()
    {
        Rigidbody[] bodies = FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
        foreach (Rigidbody body in bodies)
        {
            if (body.GetComponent<Items>() != null)
            {
                body.GetComponent<Items>().ResetPostion();
            }
        }
        chickenSlices = 0;
        pastaBoiled = false;
        chickenSliced = false;
        creamAdded = false;
        oilAdded = false;
        correctIngredients = 0;
        incorrectIngredients = 0;
        numberOfChickenSlices = 0;
        totalCookedChicken = 0;
        totalOil = 0;
        totalCreamAdded = 0;
        totalBoiledPasta = 0;
        missions.SetChecking(false);
        missions.ResetTimer();
        ingredientsArea.SetActive(false);
        bell.GetComponent<Bell>().SetDone(false);
        isActive = false;
    }

    void CalculateSatisfaction()
    {

        float multiplier;//the amount by which the satisfaction is calculated by

        //checks to see if the amount of incorrect ingredients isnt higher then the asmount of ingredients
        if (incorrectIngredients >= numberOfIngredients)
        {
            //adds zero to the satisfaction meter
            //missions.AddSatisfaction(0.0f);
        }
        else
        {
            //calculate the multiplier
            multiplier = correctIngredients - incorrectIngredients;

            //calculate the percentage of correct ingredients
            float percentageOfCorrect = multiplier / numberOfIngredients;

            //calculate the amount of satisfaction score to add
            float satisfaction = percentageOfCorrect * missions.GetSatisfactionScore();

            //add satisfaction to score
            //missions.AddSatisfaction(satisfaction);
        }
    }