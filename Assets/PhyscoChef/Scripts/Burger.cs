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
    private bool bottomBunAdded;
    private bool burgerAdded;
    private bool burgerCooked;
    private bool cheeseAdded;
    private bool lettuceAdded;
    private bool pickleAdded;
    private bool onionAdded;
    private bool tomatoAdded;
    private bool topBunAdded;
    private bool isActive;

    private int bottomBunCount;
    private int burgerCount;
    private int cookedBurgerCount;
    private int cheeseCount;
    private int lettuceCount;
    private int pickleCount;
    private int onionCount;
    private int tomatoCount;
    private int topBunCount;
    private int correctIngredients = 0;
    private int incorrectIngredients = 0;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SetActive(bool set)
    {
        isActive = set;
    }

    void CheckBottomBun(Collider col)
    {

    }

    void CheckBurger(Collider col)
    {

    }

    void CheckCheese(Collider col)
    {

    }

    void CheckLettuce(Collider col)
    {

    }

    void CheckPickle(Collider col)
    {

    }

    void CheckOnion(Collider col)
    {

    }

    void CheckTomato(Collider col)
    {

    }

    void CheckTopBun(Collider col)
    {

    }

    void CheckWhichIngredient(Collider col)
    {
        if(col.GetComponent<Food>().foodName == FoodName.BUNBOTTOM)
        {
            CheckBottomBun(col);
        }

        if(col.GetComponent<Food>().foodName == FoodName.BURGER)
        {
            CheckBurger(col);
        }

        if(col.GetComponent<Food>().foodName == FoodName.CHEESE)
        {
            CheckCheese(col);
        }

        if(col.GetComponent<Food>().foodName == FoodName.LETTUCE)
        {
            CheckLettuce(col);
        }

        if(col.GetComponent<Food>().foodName == FoodName.PICKLE)
        {
            CheckPickle(col);
        }

        if(col.GetComponent<Food>().foodName == FoodName.ONION)
        {
            CheckOnion(col);
        }

        if(col.GetComponent<Food>().foodName == FoodName.TOMATO)
        {
            CheckTomato(col);
        }

        if(col.GetComponent<Food>().foodName == FoodName.BUNTOP)
        {
            CheckTopBun(col);
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

        }
        else
        {
            incorrectIngredients --;
        }
    }
}
