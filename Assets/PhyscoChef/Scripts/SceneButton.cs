using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneButton : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField]
    private bool isGame = false;
    [SerializeField]
    private bool isMenu = false;
    [SerializeField]
    private bool isTutorial = false;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(isActive)
        {
            ChangeScene();
            isActive = false;
        }
	}

    public void SetActive(bool active)
    {
        isActive = active;
    }

    void ChangeScene()
    {
        //checks to see if scene is game
        if(isGame)
        {
            Debug.Log("game loaded");
            //loads the game scene
            SceneManager.LoadScene("game1");
        }
        //checks to see if scene is menu
        if(isMenu)
        {
            Debug.Log("menu loaded");
            //loads the menu scene
            SceneManager.LoadScene("menu");
        }
        //checks to see if scene is tutorial
        if(isTutorial)
        {
            Debug.Log("tutorial loaded");
            //loads the tutorial scene
            SceneManager.LoadScene("tutorial");
        }
    }
}
