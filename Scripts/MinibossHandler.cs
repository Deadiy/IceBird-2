using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibossHandler : MonoBehaviour
{
    public int health = 2;
    public void OnExplosion()
    {
        health--;
        if (health <= 0) Destroy(gameObject);
    }
    public void OnExplosion(int damage)
    {
        health = health - damage;
        if (health <= 0) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillZone")
        {
            Destroy(collision.gameObject);
        }
    }
}
