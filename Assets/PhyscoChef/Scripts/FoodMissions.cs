using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class FoodMissions : MonoBehaviour
{    
    private int orderNumber = 1;//the number of the recipe that is being ordered
    private bool isChecking = false;//whether or not the order is being checked
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

    // Use this for initialization
    void Start ()
    {
        //sets the mission countdown timer and reset timer
        missionCountdownResetTimer = missionCountdownTimer;
        initialTime = missionCountdownTimer;
        missionCountdownTimer = 0;
        maxSatisfaction = satisfaction;
        //missionTimerBar = GetComponent<UnityEngine.UI.Image>();
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
                    Debug.Log("new misision");
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
            SceneManager.LoadScene("gameOver");
        }
    }

    void GenerateFoodRequest()
    {
        //checks to see if the order number is order 1
        if(orderNumber == 1)
        {
            //calls the cook chicken pasta
            CookCreamyChickenPasta();
        }
    }

    void CookCreamyChickenPasta()
    {
        //sets the text to cook creamy chicken
        missionDisplayText.text = "Creamy Chicken Pasta";
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

    public void AddSatisfaction(float score)
    {
        if (satisfaction + score < maxSatisfaction)
        {
            satisfaction += score;
        }
        else
        {
            satisfaction = maxSatisfaction;
        }        
    }
}
