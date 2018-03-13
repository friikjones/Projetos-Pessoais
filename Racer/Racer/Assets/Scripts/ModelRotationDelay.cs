using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotationDelay : MonoBehaviour {

    private Vector3 directionParent;
    private Vector3 directionThis;
    //private Vector3 auxVector;

    public float followupConstant;

    public GameObject carro;
    public GameObject model;

    // Use this for initialization
    void Start () {
        directionThis = carro.transform.rotation.eulerAngles;	
	}
	
	// Update is called once per frame
	void Update () {
        
        directionParent = carro.transform.rotation.eulerAngles;
        Debug.Log("Parent - Y:" + directionParent.y);
        Debug.Log("Child - Y:" + directionThis.y);
        

        RotateThis();
	}
    
    void RotateThis ()
    {

        float aux =  (directionParent.y) - (directionThis.y%360);
        //float aux = auxVector.y;

        Debug.Log("aux: " + aux);
        
        if (aux > 1 && aux <= 90)
        {
            directionThis.y = directionThis.y + followupConstant;
        }
        if (aux < -1 && aux >= -90)
        {
            directionThis.y = directionThis.y - followupConstant;
        }
        if (aux < -90)
        {
            directionThis.y = directionThis.y + followupConstant*3;
        }
        if (aux > 90)
        {
            directionThis.y = directionThis.y - followupConstant*3;
        }

        


        Quaternion auxQuater = Quaternion.Euler(0, aux, 0);
        model.transform.localRotation = auxQuater;
    }



}
