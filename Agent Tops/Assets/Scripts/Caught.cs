using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caught : MonoBehaviour {

    GameObject[] pausedObj;

    private void Start()
    {
        pausedObj = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(waitAndPause());
            
        }
    }

    IEnumerator waitAndPause()
    {
        foreach (GameObject g in pausedObj)
        {
            print(g);
            g.SetActive(true);
        }
        print(Time.time);
        yield return new WaitForSecondsRealtime(1);
        print(Time.time);
        Time.timeScale = 0;
    }

}
