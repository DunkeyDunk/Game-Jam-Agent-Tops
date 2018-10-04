using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    public GameManager GM;
    //public MusicManager MM;

    private void Update()
    {

    }

    public void Caught()
    {
        print("Opdaget - UI");
        GM.CaughtPause();
    }
    public void Restart()
    {
        print("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GM.RestartLevel();
    }
}
