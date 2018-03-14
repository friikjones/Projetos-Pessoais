using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBallControler : MonoBehaviour {

    private Rigidbody rb;

    public float localGravity;
    public float forceMultiplier;
    public float rotateMultiplier;
    public bool sliding;
    private float slidingDampening;

    private Vector3 slidingDir;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb.AddRelativeForce(Vector3.down * localGravity);

        if(MoveFoward())
        {
            rb.AddRelativeForce(Vector3.forward * forceMultiplier);
        }
        if (MoveBackwards())
        {
            rb.AddRelativeForce(Vector3.back * forceMultiplier);
        }
        if (RotateLeft())
        {
            rb.AddRelativeTorque(Vector3.down * rotateMultiplier * slidingDampening);
        }
        if (RotateRight())
        {
            rb.AddRelativeTorque(Vector3.up * rotateMultiplier * slidingDampening);
        }

        SlideCheck();
    }

    bool MoveFoward ()
    {
        if (Input.GetKey(KeyCode.W))
            return true;
        else
            return false;
    }
    bool MoveBackwards()
    {
        if (Input.GetKey(KeyCode.S))
            return true;
        else
            return false;
    }
    bool RotateLeft()
    {
        if (Input.GetKey(KeyCode.A))
            return true;
        else
            return false;
    }
    bool RotateRight()
    {
        if (Input.GetKey(KeyCode.D))
            return true;
        else
            return false;
    }

    void SlideCheck()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (RotateLeft() && !sliding)
            {
                sliding = true;
                slidingDir = (Vector3.down);
            }
            if (RotateRight() && !sliding)
            {
                sliding = true;
                slidingDir = (Vector3.up);
            }
        }
        else
        {
            slidingDampening = 1;
            sliding = false;
        }

        if (sliding)
        {
            slidingDampening = .8f;
            rb.AddRelativeTorque(slidingDir * rotateMultiplier);
        }

    }

}
