using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public GameObject target;
	
    public Vector2 GetTarget()
    {
        Vector2 pos;
        pos = target.GetComponent<Transform>().position;
        return (pos);
    }
}
