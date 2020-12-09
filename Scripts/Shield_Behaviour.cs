using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Behaviour : MonoBehaviour
{
    public float effect;
    public int resistance = 3;


    private void FixedUpdate()
    {
        if (effect > 0f && resistance> 0)
        {
            effect -= (Time.deltaTime) * 1f;
        }
        else
        {
            gameObject.SetActive(false);
            effect = 0;
            resistance = 3;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillZone")
        {
            Destroy(collision.gameObject);
            resistance--;
        }
    }
}
