using UnityEngine;
using System.Collections;

public class Burger : MonoBehaviour
{
    [SerializeField]
    private FoodMissions missions;
    [SerializeField]
    private FoodIngredientArea ingredientsArea;
    [SerializeField]
    Bell bell;
    private bool bottomBunAdded = false;
    private bool burgerCooked = false;
    private bool cheeseAdded = false;
    private bool lettuceAdded = false;
    private bool pickleAdded = false;
    private bool onionAdded = false;
    private bool tomatoAdded = false;
    private bool topBunAdded = false;
    private bool isActive = false;
    private bool overCookedBurger = false;

    private int bottomBunCount = 0;
    private int burgerCount = 0;
    private int numberOfBurgers = 0;
    private int cookedBurgerCount = 0;
    private int overCookedBurgerCount = 0;
    private int cheeseCount = 0;
    private int lettuceCount = 0;
    private int pickleCount = 0;
    private int onionCount = 0;
    private int tomatoCount = 0;
    private int topBunCount = 0;
    private float correctIngredients = 0;
    private float incorrectIngredients = 0;
    private int numberOfIngredients = 8;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isActive)
        {
            missions.AddSatisfaction(numberOfIngredients, correctIngredients, incorrectIngredients);
            Reset();
        }
	}

    public void SetActive(bool set)
    {
        isActive = set;
    }

    void CheckBottomBun()
    {
        //a bottom bun hasn't been added
        if(!bottomBunAdded)
        {
            correctIngredients ++;
            bottomBunCount ++;
            bottomBunAdded = true;
        }
        //a bottom bun already exist
        else
        {
            incorrectIngredients++;
            bottomBunCount++;
        }
    }

    void CheckBurger(Collider col)
    {
        if(!burgerCooked)
        {
            if(col.GetComponent<Food>().GetCooked())
            {
                correctIngredients ++;
                cookedBurgerCount ++;
                numberOfBurgers ++;
                burgerCooked = true;
            }
            if(col.GetComponent<Food>().GetOverCooked())
            {
                correctIngredients += 0.5f;
                overCookedBurgerCount ++;
                numberOfBurgers++;
                burgerCooked = true;
                overCookedBurger = true;
            }
            else
            {
                incorrectIngredients ++;
                burgerCount ++;
            }
        }
        else
        {
            if(col.GetComponent<Food>().GetCooked())
            {
                incorrectIngredients ++;
                cookedBurgerCount ++;
            }
            if(col.GetComponent<Food>().GetOverCooked())
            {
                incorrectIngredients ++;
                overCookedBurgerCount ++;
            }
            else
            {
                incorrectIngredients ++;
                burgerCount ++;
            }
        }
    }

    void CheckCheese()
    {
        if(!cheeseAdded)
        {
            correctIngredients ++;
            cheeseCount ++;
            cheeseAdded = true;
        }
        else
        {
            incorrectIngredients ++;
            cheeseCount ++;
        }
    }

    void CheckLettuce()
    {
        if(!lettuceAdded)
        {
            correctIngredients++;
            lettuceCount++;
            lettuceAdded = true;
        }
        else
        {
            incorrectIngredients ++;
            lettuceCount ++;
        }
    }

    void CheckPickle()
    {
        if(!pickleAdded)
        {
            correctIngredients ++;
            pickleCount ++;
            pickleAdded = true;
        }
        else
        {
            incorrectIngredients ++;
            pickleCount ++;
        }
    }

    void CheckOnion()
    {
        if(!onionAdded)
        {
            correctIngredients ++;
            onionCount ++;
            onionAdded = true;
        }
        else
        {
            incorrectIngredients ++;
            onionCount ++;
        }
    }

    void CheckTomato()
    {
        if(!tomatoAdded)
        {
            correctIngredients ++;
            tomatoCount ++;
            tomatoAdded = true;
        }
        else
        {
            incorrectIngredients ++;
            tomatoCount ++;
        }
    }

    void CheckTopBun()
    {
        if(!topBunAdded)
        {
            correctIngredients ++;
            topBunCount ++;
            topBunAdded = true;
        }
        else
        {
            incorrectIngredients ++;
            topBunCount ++;
        }
    }

    void CheckWhichIngredient(Collider col)
    {
        if(col.GetComponent<Food>().GetName() == FoodName.BUNBOTTOM)
        {
            CheckBottomBun();
        }

        if(col.GetComponent<Food>().GetName() == FoodName.BURGER)
        {
            CheckBurger(col);
        }

        if(col.GetComponent<Food>().GetName() == FoodName.CHEESE)
        {
            CheckCheese();
        }

        if(col.GetComponent<Food>().GetName() == FoodName.LETTUCE)
        {
            CheckLettuce();
        }

        if(col.GetComponent<Food>().GetName() == FoodName.PICKLE)
        {
            CheckPickle();
        }

        if(col.GetComponent<Food>().GetName() == FoodName.ONION)
        {
            CheckOnion();
        }

        if(col.GetComponent<Food>().GetName() == FoodName.TOMATO)
        {
            CheckTomato();
        }

        if(col.GetComponent<Food>().GetName() == FoodName.BUNTOP)
        {
            CheckTopBun();
        }

    }

    void RemoveIngredient(Collider col)
    {
        if (col.GetComponent<Food>().GetName() == FoodName.BUNBOTTOM)
        {
            RemoveBottomBun();
        }

        if (col.GetComponent<Food>().GetName() == FoodName.BURGER)
        {
            RemoveBurger(col);
        }

        if (col.GetComponent<Food>().GetName() == FoodName.CHEESE)
        {
            RemoveCheese();
        }

        if (col.GetComponent<Food>().GetName() == FoodName.LETTUCE)
        {
            RemoveLettuce();
        }

        if (col.GetComponent<Food>().GetName() == FoodName.PICKLE)
        {
            RemovePickle();
        }

        if (col.GetComponent<Food>().GetName() == FoodName.ONION)
        {
            RemoveOnion();
        }

        if (col.GetComponent<Food>().GetName() == FoodName.TOMATO)
        {
            RemoveTomato();
        }

        if (col.GetComponent<Food>().GetName() == FoodName.BUNTOP)
        {
            RemoveTopBun();
        }
    }

    void RemoveBottomBun()
    {
        //check that top bun count is greater than 1
        if(bottomBunCount > 1)
        {
            //reduce  top bun count
            bottomBunCount --;
            //reduce incorrect ingredient
            incorrectIngredients --;
        }
        else
        {
            //reduce correct ingredients by one
            correctIngredients --;
            //reduce the top bun count
            topBunCount --;
            //set top bun added to false
            topBunAdded = false;
        }
    }

    void RemoveBurger(Collider col)
    {
        if(col.GetComponent<Food>().GetCooked())
        {
            RemoveCookedBurger(col);
        }
        if(col.GetComponent<Food>().GetOverCooked())
        {
            RemoveCookedBurger(col);
        }
        else
        {
            RemoveUncookedBurger();
        }
    }

    void RemoveCookedBurger(Collider col)
    {
        if (col.GetComponent<Food>().GetCooked())
        {
            numberOfBurgers--;
            cookedBurgerCount--;
            if (numberOfBurgers >= 1)
            {
                if (overCookedBurgerCount >= 1)
                {
                    if (!overCookedBurger)
                    {
                        overCookedBurger = true;
                        correctIngredients -= 0.5f;
                    }
                }
                incorrectIngredients--;
            }
            else
            {
                //reduce correct ingredients
                correctIngredients--;
                //set cooked burger added to false
                burgerCooked = false;
            }
        }
        if(col.GetComponent<Food>().GetOverCooked())
        {
            numberOfBurgers --;
            overCookedBurgerCount --;
            if(numberOfBurgers > 0)
            {
                if(overCookedBurgerCount > 0)
                {
                    if(!overCookedBurger)
                    {
                        correctIngredients -= 0.5f;
                        overCookedBurger = true;
                    }
                }
                incorrectIngredients--;
            }
            else
            {
                if(overCookedBurger)
                {
                    correctIngredients -= 0.5f;
                    overCookedBurger = false;
                    burgerCooked = false;
                }
                else
                {
                    correctIngredients --;
                    burgerCooked = false;
                }
            }
        }
    }

    void RemoveUncookedBurger()
    {
        incorrectIngredients --;
        burgerCount --;
    }

    void RemoveCheese()
    {
        //check that count is greater than 1
        if(cheeseCount > 1)
        {
            //reduce count
            cheeseCount --;
            //reduce incorrect
            incorrectIngredients --;
        }
        else
        {
            //reduce correct ingredient
            correctIngredients --;
            //reduce count
            cheeseCount --;
            //set top bun added to false
            cheeseAdded = false;
        }
    }

    void RemoveLettuce()
    {
        //check that count is greater than 1
        if (lettuceCount > 1)
        {
            //reduce count
            lettuceCount --;
            //reduce incorrect
            incorrectIngredients --;
        }
        else
        {
            //reduce correct ingredient
            correctIngredients --;
            //reduce count
            lettuceCount --;
            //set added to false
            lettuceAdded = false;
        }
    }

    void RemovePickle()
    {
        //check that count is greater than 1
        if (pickleCount > 1)
        {
            //reduce count
            pickleCount --;
            //reduce incorrect
            incorrectIngredients--;
        }
        else
        {
            //reduce correct ingredient
            correctIngredients--;
            //reduce count
            pickleCount --;
            //set added to false
            pickleAdded = false;
        }
    }

    void RemoveOnion()
    {
        //check that count is greater than 1
        if (onionCount > 1)
        {
            //reduce count
            onionCount --;
            //reduce incorrect
            incorrectIngredients--;
        }
        else
        {
            //reduce correct ingredient
            correctIngredients--;
            //reduce count
            onionCount --;
            //set added to false
            onionAdded = false;
        }
    }

    void RemoveTomato()
    {
        //check that count is greater than 1
        if (tomatoCount > 1)
        {
            //reduce count
            tomatoCount --;
            //reduce incorrect
            incorrectIngredients--;
        }
        else
        {
            //reduce correct ingredient
            correctIngredients --;
            //reduce count
            tomatoCount --;
            //set added to false
            tomatoAdded = false;
        }
    }

    void RemoveTopBun()
    {
        //check that count is greater than 1
        if (topBunCount > 1)
        {
            //reduce count
            topBunCount--;
            //reduce incorrect
            incorrectIngredients--;
        }
        else
        {
            //reduce correct ingredient
            correctIngredients--;
            //reduce count
            topBunCount--;
            //set added to false
            topBunAdded = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Food")
        {
            CheckWhichIngredient(col);
        }
        else
        {
            incorrectIngredients ++;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Food")
        {
            RemoveIngredient(col);
        }
        else
        {
            incorrectIngredients --;
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

        bottomBunAdded = false;
        burgerCooked = false;
        cheeseAdded = false;
        lettuceAdded = false;
        pickleAdded = false;
        onionAdded = false;
        topBunAdded = false;
        isActive = false;
        bottomBunCount = 0;
        burgerCount = 0;
        cookedBurgerCount = 0;
        cheeseCount = 0;
        lettuceCount = 0;
        pickleCount = 0;
        onionCount = 0;
        tomatoCount = 0;
        topBunCount = 0;
        correctIngredients = 0;
        incorrectIngredients = 0;
    }
}
