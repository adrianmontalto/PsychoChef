using UnityEngine;
using System.Collections;

public class FinishedMeal : MonoBehaviour
{
    private bool isDisplayed;
    private bool isShowing = false;
    [SerializeField]
    private float displayTime;
    private float displayResetTime;
	// Use this for initialization
	void Start ()
    {
        displayResetTime = displayTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isDisplayed)
        {
            displayTime -= Time.deltaTime;
            if(!isShowing)
            {
                this.GetComponent<MeshRenderer>().enabled = true;
            }
            if(displayTime < 0)
            {
                this.GetComponent<MeshRenderer>().enabled = false;
                isShowing = false;
                isDisplayed = false;
            }
        }
	}

    public void SetDisplay(bool set)
    {
        isShowing = set;
    }
}
