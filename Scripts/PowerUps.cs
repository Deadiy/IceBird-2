using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int ammo_points=0;
    public string type = "Default";
    public float effect_time = 0f;


    private GameObject bird;
    private Transform spawner;
    private int ammoLimit = 20;
    private void Awake()
    {
        bird = GameObject.FindGameObjectWithTag("Player");
        spawner = GameObject.FindGameObjectWithTag("Spawner").transform;
    }
    public void PowerUp(Player_Controller Player)
    {
        switch (type)
        {
            case "ammo":
                {
                    Player.rocketCount += ammo_points;
                    if (Player.rocketCount > ammoLimit)
                        Player.rocketCount = ammoLimit;
                break;
                }
            case "points":
                {
                    Player.points += ammo_points;
                    break;
                }
            case "explosion":
                {
                    for (int i = 0; i < spawner.childCount; i++)
                    {
                       if(spawner.GetChild(i).tag == "KillZone")
                        {
                            Destroy(spawner.GetChild(i).gameObject);
                        }
                        else if (spawner.GetChild(i).tag == "MiniBoss")
                        {
                            spawner.GetChild(i).gameObject.GetComponent<MinibossHandler>().OnExplosion();
                        }
                    }
                    break;
                }
            case "shield":
                {
                    GameObject child = Player.transform.GetChild(0).gameObject;
                    child.SetActive(true);
                    child.GetComponent<Shield_Behaviour>().effect = effect_time;
                    child.GetComponent<Shield_Behaviour>().resistance = 3;
                   
                    break;
                }
        }
    }
}
