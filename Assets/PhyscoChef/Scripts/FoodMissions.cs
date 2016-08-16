using UnityEngine;
using System.Collections;

public class FoodMissions : MonoBehaviour
{
    //private int randomMin = 0;
    //private int randomMax = 0;
    private float missionCountdownResetTimer = 0.0f;
    private int orderNumber = 1;
    public UnityEngine.UI.Text missionDisplayText;
    public UnityEngine.UI.Image missionTimerBar;
    public UnityEngine.UI.Image satisfactionBar;
    public float missionCountdownTimer = 0.0f;
    public float setUpDelayTimer = 0.0f;
    public float satisfaction = 0.0f;

	// Use this for initialization
	void Start ()
    {
        //sets the mission countdown timer and reset timer
        missionCountdownResetTimer = missionCountdownTimer;
        missionCountdownTimer = 0;
        //missionTimerBar = GetComponent<UnityEngine.UI.Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //reduces the delay timer
        setUpDelayTimer -= Time.deltaTime;

        //checks to see if the delay timer is less than zero
        if(setUpDelayTimer < 0)
        {
            //reduces the countdown timer
            missionCountdownTimer -= Time.deltaTime;
            //checks to see if the countdowntimer is less then zero
            if(missionCountdownTimer < 0)
            {
                Debug.Log("new misision");
                //generates the food order
                GenerateFoodRequest();
                //resets mission countdown timer
                missionCountdownTimer = missionCountdownResetTimer;
            }
        }

        missionTimerBar.rectTransform.localScale = new Vector3(1, missionCountdownTimer * 0.02f,1);
        satisfactionBar.rectTransform.localScale = new Vector3(satisfaction *0.002f, 0.3f,0.3f);
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
        missionDisplayText.text = "Cook Creamy Chicken Pasta";
    }
}
