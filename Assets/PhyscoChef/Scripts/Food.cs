using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{
    public float cookRate;//the rate at which a food cooks
    public float cookState1;//the first stage of cooking
    public float cookState2;//the scond stage of cooking
    public float cookState3;//when the food is burnt
    public Material stage1Material;//the material for the first stage
    public Material stage2Material;//the material for the second stage
    public Material burntMaterial;//the material for when it is burnt
    private bool isCooking = false;//a bool to dertermine whether the food is cooking
    private float totalCookTime;//the total time that the food has been cooked for
    private float temperature = 1.0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if the food is cooking
        if (isCooking)
        {
            //increases the cook time
            totalCookTime += cookRate * Time.deltaTime;
            //checks to see which cook stage the food is in
            CheckCookStage();
        }
    }

    void CheckCookStage()
    {
        //checks to see if the total cooktime is equal to the first cook state
        if (totalCookTime >= cookState1)
        {
            //change the foods texture to stage 1 cooked
            this.GetComponent<MeshRenderer>().material = stage1Material;
        }

        //checks to see if the total cooktime is equal to the second cook state
        if (totalCookTime >= cookState2)
        {
            //change the foods texture to stage 2 cooked
            this.GetComponent<MeshRenderer>().material = stage2Material;
        }

        //checks to see if the totatlcooktime is equal to the burnt state
        if (totalCookTime >= cookState3)
        {
            //change the food to burnt texture
            this.GetComponent<MeshRenderer>().material = burntMaterial;
        }
    }

    public void SetCooking(bool cook,float rate,float temp)
    {
        //sets the cooking state
        isCooking = cook;
        cookRate = rate;
        temperature = temp;
    }
}
