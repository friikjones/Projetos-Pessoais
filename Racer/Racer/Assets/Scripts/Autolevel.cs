using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autolevel : MonoBehaviour {

    private Rigidbody rb;
    private float factorX;
    private float factorZ;


    public float levelThreshold;
    public float levelingSpeed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        
        if (transform.rotation.eulerAngles.x < levelThreshold)
        {
            rb.AddRelativeTorque(new Vector3 (-1,0,0) * levelingSpeed);
        }
        if (transform.rotation.eulerAngles.x > -levelThreshold)
        {
            rb.AddRelativeTorque(new Vector3(1, 0, 0) * levelingSpeed);
        }
        if (transform.rotation.eulerAngles.z < levelThreshold)
        {
            rb.AddRelativeTorque(new Vector3(0, 0, -1) * levelingSpeed);
        }
        if (transform.rotation.eulerAngles.z > -levelThreshold)
        {
            rb.AddRelativeTorque(new Vector3(0, 0, 1) * levelingSpeed);
        }
        
        /*
        factorX = transform.rotation.eulerAngles.x * levelingSpeed;
        Debug.Log("X: " + factorX);
        factorZ = transform.rotation.eulerAngles.x * levelingSpeed;
        Debug.Log("Z: " + factorZ);

        transform.Rotate(factorX, 0, factorZ);
        */
    }
}
