using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CuttableObject : MonoBehaviour
{
    [SerializeField]
    private AudioClip chopSound;
    AudioSource audio;
    //public float explosiveForce = 0.0f;
    //public float explosiveRadius = 0.0f;

	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    //use to check for collisions
    void OnCollisionEnter(Collision col)
    {
       //Debug.Log("a");
       //check to see if the knife has hit the object
       if(col.gameObject.tag == "Knife")
       {
            //applies force to the fixed joint
            if(GetComponent<FixedJoint>() != null)
            {
                audio.PlayOneShot(chopSound, 0.7f);
                ExplosiveForce();
            }           
       }
    }

    void ExplosiveForce()
    {
        FixedJoint joint = GetComponent<FixedJoint>();

        this.GetComponent<Food>().SetSliced(true);
        Object.Destroy(joint);
    }
}
