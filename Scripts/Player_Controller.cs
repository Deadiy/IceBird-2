using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public bool debug = false;
    public int points, rocketCount;
    public GameObject gameHandler, rocketPrefab;
    public Spawner spawner;
    public Button jump; 
    public float score, jumpForce;


    [NonSerialized]
    public float gravity;

    private Animator m_Animator;
    private Rigidbody2D birdRB2D;
    void Awake()
    {
        birdRB2D = GetComponent<Rigidbody2D>();
        gravity = 15f;
        points = 0;
        if (debug == true)
        {
            Destroy(GetComponent<BoxCollider2D>());
            birdRB2D.bodyType = RigidbodyType2D.Static;
        }
        m_Animator = gameObject.GetComponent<Animator>();
        StartCoroutine(Gravity(1));
    }

    private void Update()
    {

        if (jump.GetComponent<ButtonStay>().buttonPressed == true && gameHandler.GetComponent<GameHandler>().touchControls == true)
        {
            Jump();
        }
        else if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && gameHandler.GetComponent<GameHandler>().touchControls == false)
        {
            Jump();
        }
        else m_Animator.ResetTrigger("Jump");
        if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && gameHandler.GetComponent<GameHandler>().touchControls == false)
        {
            Shoot();
        }

    }

    private IEnumerator Gravity(int rate)
    {
        while (true)
        {
            jumpForce = gravity;
            Debug.Log("Gravity Check!");
            yield return new WaitForSeconds(rate);
        }
        
       
    }
    void FixedUpdate()
    {       
        score = (points++ + Time.deltaTime) * 0.01f;
        //if (birdRB2D.gravityScale < 8)
        //{
        //    birdRB2D.gravityScale += (score * 0.5f) * (Time.fixedDeltaTime * 0.001f);
        //}
        gameHandler.GetComponent<GameHandler>().UpdateUI(score, transform.GetChild(0).GetComponent<Shield_Behaviour>().effect , rocketCount);
    }

    public void Jump()
    {
        m_Animator.SetTrigger("Jump");
        birdRB2D.velocity = Vector2.up * jumpForce;
    }
    public void Shoot()
    {
        if(rocketCount > 0)
        {
            //Debug.Log("PEW");
            GameObject a = Instantiate(rocketPrefab);
            a.GetComponent<Rigidbody2D>().gravityScale = 0;
            a.GetComponent<Rigidbody2D>().velocity = Vector2.right * a.GetComponent<Rocket_behaviour>().move_speed;
          //  Debug.Log(a + "- -" + a.transform.position);
            a.transform.SetParent(transform);
            a.transform.SetAsLastSibling();
            a.transform.position = transform.position;
            rocketCount--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillZone" && transform.GetChild(0).gameObject.activeSelf != true || collision.tag == "DeadZone" || collision.tag == "MiniBoss")
        {
            gameHandler.GetComponent<GameHandler>().GameOver(score);
            points = 0;
            Destroy(spawner.gameObject);
            Destroy(gameObject);
        }
        else if (collision.tag == "PowerUp")
        {
            collision.transform.GetComponent<PowerUps>().PowerUp(gameObject.GetComponent<Player_Controller>());
            Destroy(collision.gameObject);
        }



    }
}
