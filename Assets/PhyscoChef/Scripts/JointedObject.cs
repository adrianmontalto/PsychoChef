using UnityEngine;
using System.Collections;

public class JointedObject : MonoBehaviour
{
    [SerializeField]
    private GameObject joint;
    FixedJoint fixedJoint;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Reset()
    {
        fixedJoint = joint.GetComponent<GameObject>().AddComponent<FixedJoint>();
    }
}
