using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityID : MonoBehaviour
{
    public int id;
    private void Awake()
    {
        id = Mathf.CeilToInt(Random.Range(0,9999));
    }
}
