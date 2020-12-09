using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
     Destroy(collision.gameObject);
    }
}
