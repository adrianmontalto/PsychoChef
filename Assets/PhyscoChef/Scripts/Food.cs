using UnityEngine;
using System.Collections;
public enum FoodName
{
    FOOD,
    CARROT,
    BREAD,
    PASTA,
    CHICKEN,
    EGG,
    CREAM,
    OIL
};

public class Food : MonoBehaviour
{
    public float cookRate;//the rate at which a food cooks
    public float boilRate;//the rate at which the food boils
    public float partialyCookedState;//the first stage of cooking
    public float cookedState;//the scond stage of cooking
    public float burntState;//when the food is burnt
    public float partialyBoiledState;
    public float boiledState;
    public Material partialyCookedMaterial;//the material for the first stage
    public Material cookedMaterial;//the material for the second stage
    public Material burntMaterial;//the material for when it is burnt
    public FoodName foodName = FoodName.FOOD;//the name of the food
    private bool isCooking = false;//a bool to dertermine whether the food is cooking
    private bool isCooked = false;
    private bool isBoiling = false;//checks to see that the food is boiling
    private bool isBoiled = false;
    private bool isSliced = false;
    private float totalCookTime;//the total time that the food has been cooked for
    private float externalCookRate = 1.0f;//the rate of cooking applied by an external source
    private float totalBoilTime;//the total time the food has been boiling
    private float boilCookRate = 1.0f;//the rate at which boil affects cooking
    private Material intialMaterial;
    private Material currentMaterial;
 

    // Use this for initialization
    void Start()
    {
        currentMaterial = this.GetComponent<MeshRenderer>().material;
        intialMaterial = this.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if the food is cooking
        if (isCooking)
        {
            if(isBoiling == false)
            {
                //increases the cook time
                totalCookTime += cookRate * externalCookRate * Time.deltaTime;
            }              
        }

        if (isBoiling == true)
        {
            //increase the cook time byt applying the boil rate
            totalBoilTime+= boilRate * boilCookRate * Time.deltaTime;
        }
        //checks to see which cook stage the food is in
        CheckCookStage();
        CheckBoiledStage();
    }

    void CheckCookStage()
    {
        //checks to see if the total cooktime is equal to the first cook wstate
        if (totalCookTime >= partialyCookedState)
        {
            //change the foods texture to stage 1 cooked
            this.GetComponent<MeshRenderer>().material = partialyCookedMaterial;
            currentMaterial = partialyCookedMaterial;
        }

        //checks to see if the total cooktime is equal to the second cook state
        if (totalCookTime >= cookedState)
        {
            //change the foods texture to stage 2 cookedw
            this.GetComponent<MeshRenderer>().material = cookedMaterial;
            currentMaterial = cookedMaterial;
            isCooked = true;
        }

        //checks to see if the totatlcooktime is equal to the burnt state
        if (totalCookTime >= burntState)
        {
            //change the food to burnt texture
            this.GetComponent<MeshRenderer>().material = burntMaterial;
            currentMaterial = burntMaterial;
            isCooked = false;
        }
    }

    void CheckBoiledStage ()
    {
        //checks to see if the total cooktime is equal to the first cook state
        if (totalBoilTime >= partialyCookedState)
        {
            //change the foods texture to stage 1 cooked
            this.GetComponent<MeshRenderer>().material = partialyCookedMaterial;
        }

        //checks to see if the total cooktime is equal to the second cook state
        if (totalBoilTime >= cookedState)
        {
            //change the foods texture to stage 2 cooked
            this.GetComponent<MeshRenderer>().material = cookedMaterial;
            isBoiled = true;
            isCooked = false;
        }

        //checks to see if the totatlcooktime is equal to the burnt state
        if (totalBoilTime >= burntState)
        {
            //change the food to burnt texture
            this.GetComponent<MeshRenderer>().material = burntMaterial;
            isBoiled = false;
        }
    }

    public void SetCooking(bool cook, float temp)
    {
        //sets the cooking state
        isCooking = cook;
        externalCookRate = temp;
    }

    public void SetBoiling(bool boil, float temp)
    {
        //sets the boiling state
        isBoiling = boil;
        boilCookRate = temp;
    }

    public bool GetBoiled()
    {
        return isBoiled;
    }

    public bool GetCooked()
    {
        return isCooked;
    }
    
    public bool GetSliced()
    {
        return isSliced;
    }

    public void SetSliced(bool slice)
    {
        isSliced = slice;
    }

    public void ResetFood()
    {
        isBoiled = false;
        isCooking = false;
        isCooked = false;
        isBoiling = false;
        isBoiled = false;
        isSliced = false;
        totalCookTime = 0;
        totalBoilTime = 0;
        this.GetComponent<MeshRenderer>().material = intialMaterial;
    }
}
