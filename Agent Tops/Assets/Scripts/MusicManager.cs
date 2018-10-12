using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioSource landing;
    public AudioSource menuClick;
    public AudioSource lose;
    public AudioSource Music;

    public void Landing()
    {
        landing.Play();
    }

    public void MenuClick()
    {
        menuClick.Play();
    }

    public void Lose()
    {
        Music.Stop();
        lose.Play();
    }

}
