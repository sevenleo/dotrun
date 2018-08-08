using UnityEngine;
using System.Collections;

public class treasurelight : MonoBehaviour {

    
    public GameObject treasure0;
    public Camera camera;
    float maxdistance = 0f;
    float distance = 100000f;



    public GameObject sphere_prefab;
    GameObject sphere;
    float range;
    float animatespeed;


    void Start()
    {
        PlayerPrefs.SetString("GameMode", "treasurelight");
        status.special = 1;
    }

    void Update () {

        GameObject[] treasures = GameObject.FindGameObjectsWithTag("treasure");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
        
        if (status.score >= status.goal)
        {
            Instantiate<GameObject>(treasure0);
            status.maxenemys = status.maxenemys * 1.2f;
            status.securedistance *= 0.99f;
            status.goal += status.score;
            status.special = 1;
            clean(enemys);
        }
        else
        {
            foreach (GameObject treasure in treasures)
            {
                foreach (GameObject enemy in enemys){
                    float newdistance = Vector3.Distance(enemy.transform.position, treasure.transform.position);
                    if (newdistance < distance) distance=newdistance;
                    if (newdistance > maxdistance) maxdistance=newdistance;
                    //print(treasures.Length +" " +enemys.Length +" "+"D: " + distance+" / "+maxdistance);
                    camera.backgroundColor = Color.Lerp(Color.black, Color.white, distance/maxdistance);
                }
            }            
        }


    }


    void clean(GameObject[] enemys){
        foreach (GameObject enemy in enemys){
            Destroy(enemy);
        }

        camera.backgroundColor = Color.white;
        maxdistance = 1f;
        distance = 100000f;
    }



}
