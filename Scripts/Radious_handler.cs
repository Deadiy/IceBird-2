using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radious_handler : MonoBehaviour
{
    public float move_speed = 20f;

    int parentId;
    GameObject parent;
    private void Awake()
    {
        parent = transform.GetComponentInParent<EntityID>().gameObject;
        parentId = transform.GetComponentInParent<EntityID>().id;
    }
    private void FixedUpdate()
    {
        if(tag != "PowerUp")
        {
           transform.GetChild(0).transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, (move_speed*0.05f)));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;

        if (collision.tag == transform.tag)
        {
            Destroy(other);
            Destroy(gameObject);
        }



        //Debug.Log("Crash");
        //if (collision.tag == "KillZone"|| collision.tag == "PowerUp")
        //{
        //    int target = Random.Range(0, 200);
        //    switch (target%2)
        //    {
        //        case 0:
        //            {
        //                Destroy(gameObject);
        //                break;
        //            }
        //        case 1:
        //            {
        //                Destroy(other);
        //                break;
        //            }
        //    }
           
        //}
        }
    }
