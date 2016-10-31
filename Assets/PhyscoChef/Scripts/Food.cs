using UnityEngine;
using System.Collections;
public enum FoodName
{
    FOOD,
    PASTA,
    CHICKEN,
    CHEESE,
    ONION,
    LETTUCE,
    PICKLE,
    BUNTOP,
    BUNBOTTOM,
    BURGER,
    TOMATO
};

public class Food : MonoBehaviour
{
    [SerializeField]
    private float cookRate;//the rate at which a food cooks
    [SerializeField]
    private float boilRate;//the rate at which the food boils
    [SerializeField]
    private float partialyCookedState;//the first stage of cooking
    [SerializeField]
    private float overCookedState;
    [SerializeField]
    private float cookedState;//the scond stage of cooking
    [SerializeField]
    private float burntState;//when the food is burnt
    [SerializeField]
    private float partialyBoiledState;
    [SerializeField]
    private float boiledState;
    [SerializeField]
    private Material partialyCookedMaterial;//the material for the first stage
    [SerializeField]
    private Material cookedMaterial;//the material for fully cooked
    [SerializeField]
    private Material overCookedMaterial;//the material for overcooked
    [SerializeField]
    private Material burntMaterial;//the material for when it is burnt
    [SerializeField]
    private FoodName foodName = FoodName.FOOD;//the name of the food
    private bool isCooking = false;//a bool to dertermine whether the food is cooking
    private bool isCooked = false;//whether the food is cooked
    private bool isOverCooked = false;//whether the food is overcooked
    private bool isBoiling = false;//checks to see that the food is boiling
    private bool isBoiled = false;
    private bool isSliced = false;
    private float totalCookTime;//the total time that the food has been cooked for
    private float externalCookRate = 1.0f;//the rate of cooking applied by an external source
    private float totalBoilTime;//the total time the food has been boiling
    private float boilCookRate = 1.0f;//the rate at which boil affects cooking
    private Material intialMaterial;

    // Use this for initialization
    void Start()
    {
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
        }

        //checks to see if the total cooktime is equal to the second cook state
        if (totalCookTime >= cookedState)
        {
            //change the foods texture to stage 2 cookedw
            this.GetComponent<MeshRenderer>().material = cookedMaterial;
            isCooked = true;
        }

        //checks to see if the food is overcooked
        if(totalCookTime >= overCookedState)
        {
            //changes the foods texture to overcooked
            this.GetComponent<MeshRenderer>().material = overCookedMaterial;
            isOverCooked = true;
        }

        //checks to see if the totatlcooktime is equal to the burnt state
        if (totalCookTime >= burntState)
        {
            //change the food to burnt texture
            this.GetComponent<MeshRenderer>().material = burntMaterial;
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

        //checks to see if the food is overcooked
        if (totalBoilTime >= overCookedState)
        {
            //changes the foods texture to overcooked
            this.GetComponent<MeshRenderer>().material = overCookedMaterial;
            isOverCooked = true;
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
        isOverCooked = false;
        isBoiling = false;
        isBoiled = false;
        isSliced = false;
        totalCookTime = 0;
        totalBoilTime = 0;
        this.GetComponent<MeshRenderer>().material = intialMaterial;
    }

    public FoodName GetName()
    {
        return foodName;
    }

    public bool Get
}
