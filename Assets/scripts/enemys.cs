using UnityEngine;
using System.Collections;

public class enemys : MonoBehaviour {

    public GameObject enemy;
    float ControlTimeRate=0f;
    float ControlTime;
    public int HowMany=1;
    Vector3 screen;


    void Start () {
        ControlTime = Time.time + ControlTimeRate;
        screen = new Vector3(Screen.width, Screen.height, status.z);
        screen = Camera.main.ScreenToWorldPoint(screen);
    }

    void Update()
    {

        ///////// DOTRUN  /////////
        if (PlayerPrefs.GetString("GameMode") == "dotrun")
        {
            HowMany = GameObject.FindGameObjectsWithTag("enemy").Length;
            if (Time.time > ControlTime && HowMany < status.maxenemys && !status.wait )
            {
                ControlTime = Time.time + ControlTimeRate;
                Vector3 center = GameObject.FindGameObjectWithTag("Player").transform.position;

                Vector3 pos = RandomCircle(center, status.maxscreenside * status.securedistance, status.maxscreenside * status.securedistance * 1.5f);
                //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
                Instantiate(enemy, pos, Quaternion.identity);
            }
        }


        ///////// TREASURE  /////////
        else if (PlayerPrefs.GetString("GameMode") == "treasure")
        {
            HowMany = GameObject.FindGameObjectsWithTag("enemy").Length;
            if (Time.time > ControlTime && HowMany < status.maxenemys && !status.wait )
            {
                ControlTime = Time.time + ControlTimeRate;
                Vector3 center = GameObject.FindGameObjectWithTag("Player").transform.position;

                Vector3 pos = RandomCircle(center, status.maxscreenside * status.securedistance, status.maxscreenside * status.securedistance * 1.5f);
                //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
               Instantiate(enemy, pos, Quaternion.identity);
               
            }
        }


        ///////// GRAVITY /////////
        else if (PlayerPrefs.GetString("GameMode") == "gravity")
        {
            HowMany = GameObject.FindGameObjectsWithTag("enemy").Length;
            if (Time.time > ControlTime && HowMany < status.maxenemys && !status.wait )
            {
                ControlTime = Time.time + ControlTimeRate;
                Vector3 center = GameObject.FindGameObjectWithTag("Player").transform.position;

                Vector3 pos = RandomCircle(center, status.maxscreenside * status.securedistance, status.maxscreenside * status.securedistance * 1.5f);

                //Vector3 pos = center + new Vector3(Random.Range(-screen.x, screen.x), Random.Range(screen.y, screen.y*2),0);
                //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
                Instantiate(enemy, pos, Quaternion.identity);
            }
        }



        ///////// SNOOKER /////////
        else if (PlayerPrefs.GetString("GameMode") == "snooker")
        {


        }


    }



//////////////////////////////////////////////////////////////////////////////////


    Vector3 RandomCircle(Vector3 center, float radiusmin, float radiusmax)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + Random.Range(radiusmin, radiusmax) * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + Random.Range(radiusmin, radiusmax) * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = 0*status.z;
        return pos;
    }

}
