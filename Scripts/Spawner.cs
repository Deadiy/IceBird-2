using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public Vector2 x_range, y_range;
    public float spawnrate,move_speed = 1;
    public GameHandler handler;
    public GameObject miniboss;
    public GameObject[] enemies, powerups;
    

    List<Vector3> xList;

    private float difficulty = 0;


    void FixedUpdate()
    {
        Spawn();
    }

    private void Spawn()
    {  
        StartCoroutine(Create(spawnrate));
       
    }
    IEnumerator Create(float rate)
    {
        while (true)
        {

            if (transform.childCount < Mathf.Ceil(difficulty) || transform.childCount <= 0)
            {
                GameObject a = Instantiate(RandomSpawn());
                a.transform.SetParent(transform);
                Vector3 newposition = CheckPosition(rate);
                a.transform.position = newposition;
                //a.GetComponent<ConstantForce2D>().force = new Vector2(-move_speed, 0f);
                a.GetComponent<Rigidbody2D>().velocity = Vector2.left * (a.GetComponent<Radious_handler>().move_speed * move_speed);
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.GetComponent<Rigidbody2D>().velocity = Vector2.left * (transform.GetChild(i).transform.GetComponent<Radious_handler>().move_speed * move_speed);
            } 
            if (difficulty <= 10) difficulty += Time.deltaTime * 0.05f;
            yield return new WaitForSeconds(rate);
        
        }
    }

    private Vector3 CheckPosition(float rate)
    {
        Vector3 pos = new Vector3(Random.Range(x_range.x, x_range.y + rate), Random.Range(y_range.x, y_range.y), 0);
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 child = transform.GetChild(i).position;
            if (pos.x == child.x || pos.x  == child.x + 10 || pos.x == child.x -10)
                pos = new Vector3(Random.Range(x_range.x, x_range.y + rate), pos.y, 0);
        }
        return pos;
    }

    public GameObject RandomSpawn()
    {
        GameObject a;
        int r = Mathf.CeilToInt(Random.Range(1f, 10f));

        if (r <= 2 && GameObject.FindGameObjectsWithTag("PowerUp").Length < 3)
        {
            a = powerups[Random.Range(0, powerups.Length)];
        }
        else a = enemies[Random.Range(0, enemies.Length)];

        if (handler.gscore >= 80 && transform.childCount % 2 == 0 && GameObject.FindGameObjectsWithTag("MiniBoss").Length < 1)
            a = miniboss;
        return a;
    }
}
