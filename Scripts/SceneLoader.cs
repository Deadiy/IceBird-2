using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void ResetScene()
    {
        Play();
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("highscore", 0);
    }
    public void Main_Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
