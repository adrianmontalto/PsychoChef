using UnityEngine;
using System.Collections;

public class CuttableObject : MonoBehaviour
{
    //public float explosiveForce = 0.0f;
    //public float explosiveRadius = 0.0f;

	// Use this for initialization
	void Start ()
    {

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
                ExplosiveForce();
            }           
       }
    }

    void ExplosiveForce()
    {
        FixedJoint joint = GetComponent<FixedJoint>();
        Rigidbody rb = this.GetComponent<Rigidbody>();

        this.GetComponent<Food>().SetSliced(true);
        //rb.AddExplosionForce(explosiveForce,this.transform.position,explosiveRadius);
        //joint.connectedBody.AddExplosionForce(explosiveForce, joint.transform.position, explosiveRadius);
        Object.Destroy(joint);
    }
}
