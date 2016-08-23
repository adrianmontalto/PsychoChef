using UnityEngine;
using System.Collections;

public class Bell : MonoBehaviour
{
    private bool isDone = false;
    public FoodIngredientArea ingredientsArea;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SetDone(bool done)
    {
        //sets the is done value
        isDone = done;
    }
}
