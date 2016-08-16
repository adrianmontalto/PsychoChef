﻿using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{
    public float cookRate;//the rate at which a food cooks
    public float cookState1;//the first stage of cooking
    public float cookState2;//the scond stage of cooking
    public float cookState3;//when the food is burnt
    public Material partialyCookedMaterial;//the material for the first stage
    public Material cookedMaterial;//the material for the second stage
    public Material burntMaterial;//the material for when it is burnt
    private bool isCooking = false;//a bool to dertermine whether the food is cooking
    private bool isBoiling = false;//checks to see that the food is boiling
    private float totalCookTime;//the total time that the food has been cooked for
    private float externalCookRate = 1.0f;//the rate of cooking applied by an external source
    private float boilCookRate = 1.0f;//the rate at which boil affects cooking


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
            if (isBoiling)
            {
                //increases the cook time of the food
                totalCookTime += cookRate * externalCookRate * boilCookRate * Time.deltaTime;
            }
            else
            {
                //increases the cook time
                totalCookTime += cookRate * externalCookRate * Time.deltaTime;
            }
        }

        if (isBoiling == true)
        {
            //increase the cook time byt applying the boil rate
            totalCookTime += cookRate * boilCookRate * Time.deltaTime;
        }
        //checks to see which cook stage the food is in
        CheckCookStage();
    }

    void CheckCookStage()
    {
        //checks to see if the total cooktime is equal to the first cook state
        if (totalCookTime >= cookState1)
        {
            //change the foods texture to stage 1 cooked
            this.GetComponent<MeshRenderer>().material = partialyCookedMaterial;
        }

        //checks to see if the total cooktime is equal to the second cook state
        if (totalCookTime >= cookState2)
        {
            //change the foods texture to stage 2 cooked
            this.GetComponent<MeshRenderer>().material = cookedMaterial;
        }

        //checks to see if the totatlcooktime is equal to the burnt state
        if (totalCookTime >= cookState3)
        {
            //change the food to burnt texture
            this.GetComponent<MeshRenderer>().material = burntMaterial;
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
        isBoiling = boil;
        boilCookRate = temp;
    }
}
