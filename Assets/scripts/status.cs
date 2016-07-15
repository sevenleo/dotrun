using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class status : MonoBehaviour {
    public GameObject specialbar;
    static public float speciallimit { get; set; }
    static public float ballsize { get; set; }
    static public float special { get; set; }
    static public float securedistance { get; set; }
    static public float maxenemys { get; set; }
    static public float enemyspeed { get; set; }
    static public int score { get; set; }
    static public bool wait;
    static public float maxscreenside { get; set; }
    static public float minscreenside { get; set; }
    static public int z = 10;
    static public float defensevalue = 1f;
    static public bool gravity;
    static public bool GodMode;
    static public float traillife=0.2f;
    static public float playerspeed = 0.2f;
    static public string GameMode;
    int x, y;
    int goal;
    Vector3 screen;

    void Start()
    {
        
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
        maxscreenside = (screen.x > screen.y) ? screen.x : screen.y;
        minscreenside = (screen.x < screen.y) ? screen.x : screen.y;
        /*speciallimit=17f;
        enemyspeed = 1.5f;
        maxenemys = 5;
        securedistance = 2f;
        wait = false;
        special = 5;*/
        score = 0;
        goal = 5;
        Load();
    }


    void Update()
    {
        if ( score> PlayerPrefs.GetInt("bestscore") || PlayerPrefs.GetInt("bestscore")==0 )
            PlayerPrefs.SetInt("bestscore", score);

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("startup");

        if (special > 0) specialbar.transform.localScale = new Vector3(special / 17f, 1f, 1f);
        else specialbar.transform.localScale = Vector3.zero;

        special += Time.deltaTime;
        
        GameObject.Find("centertxt").GetComponent<Text>().text = "" + (int)status.score;

        if (score > goal)
        {
            maxenemys = maxenemys * 1.5f;
            goal = goal * 2;
            if (special < speciallimit) special *= 1.5f;
            securedistance *= 0.99f;
        }
    }




    void Load()
    {
        traillife = PlayerPrefs.GetFloat("traillife");
        maxenemys = PlayerPrefs.GetFloat("maxenemys");
        enemyspeed = PlayerPrefs.GetFloat("enemyspeed");
        special = PlayerPrefs.GetFloat("special");
        speciallimit = PlayerPrefs.GetFloat("speciallimit");
        ballsize = PlayerPrefs.GetFloat("ballsize");
        securedistance = PlayerPrefs.GetFloat("securedistance");
        defensevalue = PlayerPrefs.GetFloat("defensevalue");
        GameMode = PlayerPrefs.GetString("GameMode");

        if (PlayerPrefs.GetString("GameMode") == "dotrun")
        {
            gravity = false;
        }
        else if (PlayerPrefs.GetString("GameMode") == "gravity")
        {
            gravity = true;
        }
        else if (PlayerPrefs.GetString("GameMode") == "snooker")
        {
            gravity = false;
        }

        if (PlayerPrefs.GetInt("GodMode") == 1)
            GodMode = true;
        else
            GodMode = false;

    }
}
