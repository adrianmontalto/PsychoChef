using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class FoodMissions : MonoBehaviour
{
    private GameObject previousImage;
    [SerializeField]
    private GameObject InitImage;
    [SerializeField]
    private GameObject pastaRecipeImage;
    [SerializeField]
    private GameObject burgerRecipeImage;
    [SerializeField]
    private UnityEngine.UI.Text missionDisplayText;//the text to display what is required to be cooked
    [SerializeField]
    private UnityEngine.UI.Image missionTimerBar;//a image to show how much time is left to cook thye meal
    [SerializeField]
    private UnityEngine.UI.Image satisfactionBar;//a image to represent the customers satisfaction
    [SerializeField]
    private float missionCountdownTimer = 0.0f;//a timer to countdown how long to do the mission
    [SerializeField]
    private float setUpDelayTimer = 0.0f;//a delay timer to allow the player time to set up
    [SerializeField]
    private float satisfaction = 0.0f;//the level of satisfaction the customer has
    [SerializeField]
    private float satisfactionDecreaseRate;//the rate at which satisfaction decreases
    private float timeUsed = 0.0f;//the amount of time used
    private float timeLeft = 0.0f;//the amount of time left
    private float initialTime = 0.0f;//the initial countdown timer
    private float maxSatisfaction;// the max amount of satisfaction
    private float missionCountdownResetTimer = 0.0f;//a timer to reset the timer for the next meal
    [SerializeField]
    private float satisfactionScore = 0.0f;//the amount of points you get if you complete the recipe
    [SerializeField]
    private int numberOfIncorrectAllowed = 0;
    private int orderNumber = 0;//the number of the recipe that is being ordered
    private bool isChecking = false;//whether or not the order is being checked
    // Use this for initialization
    void Start ()
    {
        //sets the mission countdown timer and reset timer
        missionCountdownResetTimer = missionCountdownTimer;
        initialTime = missionCountdownTimer;
        missionCountdownTimer = 0;
        maxSatisfaction = satisfaction;
        orderNumber = Random.Range(1, 2);
        previousImage = InitImage;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!isChecking)
        {
            //reduces the delay timer
            setUpDelayTimer -= Time.deltaTime;

            //checks to see if the delay timer is less than zero
            if (setUpDelayTimer < 0)
            {
                //reduces the countdown timer
                missionCountdownTimer -= Time.deltaTime;
                satisfaction -= satisfactionDecreaseRate * Time.deltaTime;
                //checks to see if the countdowntimer is less then zero
                if (missionCountdownTimer < 0)
                {
                    //Debug.Log("new misision");
                    //generate a new random number
                    orderNumber = Random.Range(1, 2);
                    //generates the food order
                    GenerateFoodRequest();
                    //resets mission countdown timer
                    missionCountdownTimer = missionCountdownResetTimer;
                }
                missionTimerBar.fillAmount = CalculateTimer(missionCountdownTimer, 0, missionCountdownResetTimer, 0, 1);
                satisfactionBar.fillAmount = CalculateTimer(satisfaction, 0, maxSatisfaction, 0, 1);
            }
        }
        
        if(satisfaction <= 0)
        {
            SceneManager.LoadScene("menu");
        }
    }

    void GenerateFoodRequest()
    {
        //checks to see if the order number is order 1
        if(orderNumber == 1)
        {
            previousImage.SetActive(false);
            pastaRecipeImage.SetActive(true);
            previousImage = pastaRecipeImage;
            //calls the cook chicken pasta
            CookCreamyChickenPasta();
        }
        if(orderNumber == 2)
        {
            previousImage.SetActive(false);
            burgerRecipeImage.SetActive(true);
            previousImage = burgerRecipeImage;
            CookBurger();
        }
    }

    void CookCreamyChickenPasta()
    {
        //sets the text to cook creamy chicken
        missionDisplayText.text = "Cook Creamy Chicken Pasta";
    }

    void CookBurger()
    {
        //sets the text to cook burger
        missionDisplayText.text = "cook Burger";
    }

    public int GetOrderNumber()
    {
        //returns the number of the order
        return orderNumber;
    }

    public void SetChecking(bool check)
    {
        //sets the ischecking bool
        isChecking = check;
    }
    
    public float GetTimeUsed()
    {
        timeUsed = missionCountdownTimer;
        return timeUsed;
    }

    public float GetTimeLeft()
    {
        timeLeft = missionCountdownResetTimer - missionCountdownTimer;
        return timeLeft;
    }

    public void ResetTimer()
    {
        missionCountdownTimer = initialTime;
    }

    private float CalculateTimer(float value, float inMin,float inMax,float outMin,float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    public float GetSatisfactionScore()
    {
        return satisfactionScore;
    }

    public void AddSatisfaction(float numberOfIngredients,int numberOfCorrect,int numberOfIncorrect)
    {
        //checks that the number or incorrect ingredients are less then the amount of mistakes allowed
        if(numberOfIncorrect < numberOfIncorrectAllowed)
        {
            //checks that the amount of incorrect is less than the number of ingredients
            if(numberOfIncorrect < numberOfIngredients)
            {
                //minus the amount of incorrect ingredients from the correct ingredients
                int num = numberOfCorrect - numberOfIncorrect;
                //makes sure the num of correct ingredients are more then zero
                if(num > 0)
                {
                    //calculate the percentage of correct ingredients
                    float multiplier = numberOfIngredients / num;
                    //adds to the satisfaction score
                    satisfaction += multiplier * satisfactionScore;
                }
                //the number of incorrect ingredients are equal to or moire then the number of correct ingredients
                else
                {
                    //adds to the satisfaction score
                    satisfaction += 0;
                }
            }
            //the number of incorrect ingredients are more than the number of ingredients
            else
            {
                //adds to the satisfaction score
                satisfaction += 0;
            }
        }
        //the number of incorrect ingredients are more than what is allowed
        else
        {
            //adds to the satisfaction score
            satisfaction += 0;
        }
    }
}
