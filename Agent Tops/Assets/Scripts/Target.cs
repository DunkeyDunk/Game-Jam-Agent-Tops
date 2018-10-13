using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public GameObject target;
	
    //Gets the posistion where you teleport to using the doors
    //and returns it to the change level script
    public Vector2 GetTarget()
    {
        Vector2 pos;
        pos = target.GetComponent<Transform>().position;
        return (pos);
    }
}
