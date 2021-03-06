﻿using UnityEngine;
using System.Collections;

public class CuttingScript : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Knife")
        {
            Vector3 cutPoint = transform.InverseTransformPoint(other.contacts[0].point);

            Transform objectTransform = transform;

            if (cutPoint.x < objectTransform.position.x)
            {
                return;
            }

            bool checking = true;

            int count = 1;

            Rigidbody rb = GetComponent<Rigidbody>();

            float xLocation = 0;

            while (checking == true && objectTransform.childCount != 0)
            {
                for (int i = 0; i < objectTransform.childCount; ++i)
                {
                    if (objectTransform.GetChild(i).tag == "Food")
                    {
                        objectTransform = objectTransform.GetChild(i);
                    }
                }

                xLocation += objectTransform.localPosition.x;

                if (cutPoint.x < xLocation)
                {                    
                    Debug.LogError("Cutpoint");
                    checking = false;

                    objectTransform.parent = null;

                    Rigidbody otherRb = objectTransform.gameObject.AddComponent<Rigidbody>();

                    if (objectTransform.childCount != 0)
                    {
                        objectTransform.gameObject.AddComponent<CuttingScript>();
                    }

                    otherRb.mass = rb.mass - count * 10;

                    otherRb.velocity = rb.velocity;

                    rb.mass = count * 10;

                    if (transform.childCount == 0)
                    {
                        Destroy(this);
                    }

                    this.GetComponent<Food>().SetSliced(true);

                    return;
                }

                count++;
            }
        }
    }
}