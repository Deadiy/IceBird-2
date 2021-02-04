using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameHandler : MonoBehaviour
{
    public int highScore;
    public int gscore;
    public Text points, highscore, rockets, shieldTime;

    public Player_Controller player;
    public GameOver gameOver;
    public GameObject jump_btn,shoot_btn;
    public Spawner spawner;

    public bool touchControls;
    private void Awake()
    {
        if (PlayerPrefs.GetString("TouchControls") == "On")
        {
            jump_btn.SetActive(true);
            shoot_btn.SetActive(true);
            touchControls = true;
        }
        else
        if (PlayerPrefs.GetString("TouchControls") == "Off")
        {
            jump_btn.SetActive(false);
            shoot_btn.SetActive(false);
            touchControls = false;
        }
        gameOver.gameObject.SetActive(false);
        highScore = PlayerPrefs.GetInt("highscore");
        highscore.text = " HighScore: " + highScore.ToString();
        StartCoroutine(DifficultySpikes());
    }

    public void UpdateUI(float score,float shield_time , int rocketcount)
    {
        gscore = Mathf.FloorToInt(score);
        points.text = "Points: " + gscore.ToString();
        rockets.text = "Rockets: " + rocketcount.ToString();
        if (shield_time > 0f)
        {
            shieldTime.gameObject.SetActive(true);
            shieldTime.text = "Shield Time: " + Mathf.FloorToInt(shield_time).ToString();
        }
        else shieldTime.gameObject.SetActive(false);
    }

    private IEnumerator DifficultySpikes()
    {
        while (true)
        {
            switch (gscore)
            {
                case 5:
                    Snappy(2);
                    break;
                case 10:
                    Snappy(2.5f);
                    break;
                case 20:
                    Snappy(3);
                    break;
                case 30:
                    Snappy(3.5f);
                    break;
                case 40:
                    Snappy(4);
                    break;
                case 100:
                    Snappy(5);
                    break;
                default:
                    break;
            }
            Debug.Log("Checked Score");
        yield return new WaitForSeconds(0.25f);
        }
    }

    private void Snappy(float modifier)
    {
        spawner.move_speed = modifier;
        if (player.gravity > 2f)
        {
            player.gravity = player.gravity - (modifier * 0.0025f);
        }
            
        
    }

    public void GameOver(float score)
    {
        if (highScore <= score)
        {
            PlayerPrefs.SetInt("highscore", Mathf.FloorToInt(score));
        }
        gameOver.gameObject.SetActive(true);
        jump_btn.SetActive(false);
        shoot_btn.SetActive(false);

    }

}
