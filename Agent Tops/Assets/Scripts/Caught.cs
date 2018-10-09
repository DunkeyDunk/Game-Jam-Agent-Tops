using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caught : MonoBehaviour {

    public UI_Manager UI;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("Opdaget - Start");
            UI.Caught();
        }
    }
}
