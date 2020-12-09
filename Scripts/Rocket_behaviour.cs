using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_behaviour : MonoBehaviour
{
    public int move_speed = 50;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillZone")
        {
            transform.parent.GetComponent<Player_Controller>().points += 200;
            Destroy(collision.gameObject); Destroy(gameObject);
        }
        if (collision.tag == "MiniBoss")
        {
             collision.GetComponent<MinibossHandler>().OnExplosion();
             Destroy(gameObject);
        }
        else if(collision.tag == "DeadZone") Destroy(gameObject);
    }
}
