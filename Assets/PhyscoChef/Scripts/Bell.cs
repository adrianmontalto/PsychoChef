using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Bell : MonoBehaviour
{
    private bool isDone = false;
    new AudioSource audio;
    public FoodIngredientArea ingredientsArea;
	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isDone == true)
        {
            audio.PlayOneShot(audio.clip, 0.7f);
            Debug.Log("ding");
            ingredientsArea.SetActive(true);
          
        }
	}

    public void SetDone(bool done)
    {
        //sets the is done value
        isDone = done;
    }
}
