using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public Text points, highscore, points_old, highscore_old, shieldTime,rockets;
    private Animator m_Animator;
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetTrigger("Pop Up");
        points.text = points_old.text;
        highscore.text = highscore_old.text;
        points_old.gameObject.SetActive(false);
        highscore_old.gameObject.SetActive(false);
        shieldTime.gameObject.SetActive(false);
        rockets.gameObject.SetActive(false);
    }
}
