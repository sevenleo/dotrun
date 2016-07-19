using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class status : MonoBehaviour {

    //OBJ
    public GameObject specialbar;
    public GameObject treasure;

    //COLORS
    static public Color playercolor { get; set; }
    static public Color bgcolor { get; set; }

    //FLOAT
    static public float speciallimit { get; set; }
    static public float ballsize { get; set; }
    static public float special { get; set; }
    static public float securedistance { get; set; }
    static public float maxenemys { get; set; }
    static public float enemyspeed { get; set; }
    static public float defensevalue = 1f;
    static public float traillife = 0.2f;
    static public float playerspeed = 0.5f;
    static public float z = 10;

    //screen
    static public float maxscreenside { get; set; }
    static public float minscreenside { get; set; }
    //static public float screenx = 9.2f;
    //static public float screen_x = -9.2f;
    //static public float screeny = 6.8f;
    //static public float screen_y = -4.8f;
    //static public float maxscreenside = 9.2f;
    //static public float minscreenside = 4.8f;

    //INT
    static public int score { get; set; }
    static public int goal;


    //BOOL
    static public bool wait { get; set; }
    static public bool gravity;
    static public bool GodMode;
    static public bool debug;

    //STRING
    static public string GameMode;

    //PRIVATES
    Vector3 screen;
    int x, y;



    void Start()
    {
        Camera.main.backgroundColor = bgcolor;
        GameObject.Find("centertxt").GetComponent<Text>().color = playercolor;
        GameObject.Find("CirclePlayer").GetComponent<SpriteRenderer>().color = playercolor;

        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
        maxscreenside = (screen.x > screen.y) ? screen.x : screen.y;
        minscreenside = (screen.x < screen.y) ? screen.x : screen.y;
        score = 0;
        //goal = 10;
        Load();
    }


    void Update()
    {
        GameObject.Find("centertxt").GetComponent<Text>().text = "" + status.score;
        SetBestScore();
        //SpecialBar();
        //Goal();
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("startup");
    }




    void Load()
    {
        traillife = PlayerPrefs.GetFloat("traillife");
        maxenemys = PlayerPrefs.GetFloat("maxenemys");
        enemyspeed = PlayerPrefs.GetFloat("enemyspeed");
        special = PlayerPrefs.GetFloat("special");
        speciallimit = PlayerPrefs.GetFloat("speciallimit");
        goal = PlayerPrefs.GetInt("goal");
        ballsize = PlayerPrefs.GetFloat("ballsize");
        securedistance = PlayerPrefs.GetFloat("securedistance");
        defensevalue = PlayerPrefs.GetFloat("defensevalue");
        GameMode = PlayerPrefs.GetString("GameMode");



        if (GameMode == "gravity")
            gravity = true;
        else
            gravity = false;


        if (PlayerPrefs.GetInt("GodMode") == 1)
            GodMode = true;
        else
            GodMode = false;

        if (PlayerPrefs.GetInt("debug") == 1)
            debug = true;
        else
            debug = false;

    }


    void SetBestScore()
    {

        ///////// DOTRUN  /////////
        if (PlayerPrefs.GetString("GameMode") == "dotrun")
        {

            if (score > PlayerPrefs.GetInt("bestscore_dotrun"))
                PlayerPrefs.SetInt("bestscore_dotrun", score);
        }

        ///////// TREASURE  /////////
        else if (PlayerPrefs.GetString("GameMode") == "treasure")
        {

            if (score > PlayerPrefs.GetInt("bestscore_treasure"))
                PlayerPrefs.SetInt("bestscore_treasure", score);
        }

        ///////// GRAVITY /////////
        else if (PlayerPrefs.GetString("GameMode") == "gravity")
        {

            if (score > PlayerPrefs.GetInt("bestscore_gravity"))
                PlayerPrefs.SetInt("bestscore_gravity", score);
        }

        ///////// SNOOKER /////////
        else if (PlayerPrefs.GetString("GameMode") == "snooker")
        {

            if (score > PlayerPrefs.GetInt("bestscore_snooker"))
                PlayerPrefs.SetInt("bestscore_snooker", score);
        }

    }

    /*
    void Goal() {

        ///////// DOTRUN  /////////
        if (PlayerPrefs.GetString("GameMode") == "dotrun")
        {
            if (score > goal)
            {
                maxenemys = maxenemys * 1.2f;
                goal = goal * 2;
                if (special < speciallimit) special *= 1.5f;
                securedistance *= 0.99f;
            }
        }

        ///////// TREASURE  /////////
        else if (PlayerPrefs.GetString("GameMode") == "treasure")
        {
            if (score > goal)
            {
                maxenemys = maxenemys * 1.2f;
                goal = goal * 2;
                if (special < speciallimit) special *= 1.5f;
                securedistance *= 0.99f;
            }
        }

        ///////// GRAVITY /////////
        else if (PlayerPrefs.GetString("GameMode") == "gravity")
        {
            if (score > goal)
            {
                maxenemys = maxenemys * 1.2f;
                goal = goal * 2;
                if (special < speciallimit) special *= 1.5f;
                securedistance *= 0.99f;
            }
        }

        ///////// SNOOKER /////////
        else if (PlayerPrefs.GetString("GameMode") == "snooker")
        {

        }

    }
    */


    void SpecialBar()
    {



        ///////// DOTRUN  /////////
        if (PlayerPrefs.GetString("GameMode") == "dotrun")
        {
            if (special > 0) specialbar.transform.localScale = new Vector3(special / 17f, 1f, 1f);
            else specialbar.transform.localScale = Vector3.zero;
            special += Time.deltaTime;
        }

        ///////// TREASURE  /////////
        else if (PlayerPrefs.GetString("GameMode") == "treasure")
        {
            if (special > 0) specialbar.transform.localScale = new Vector3(special / 17f, 1f, 1f);
            else specialbar.transform.localScale = Vector3.zero;
        }

        ///////// GRAVITY /////////
        else if (PlayerPrefs.GetString("GameMode") == "gravity")
        {
            if (special > 0) specialbar.transform.localScale = new Vector3(special / 17f, 1f, 1f);
            else specialbar.transform.localScale = Vector3.zero;
        }

        ///////// SNOOKER /////////
        else if (PlayerPrefs.GetString("GameMode") == "snooker")
        {

        }
    }


    void defaultvalues()
    {
        ///////// DOTRUN  /////////
        if (PlayerPrefs.GetString("GameMode") == "dotrun")
        {

        }

        ///////// TREASURE  /////////
        else if (PlayerPrefs.GetString("GameMode") == "treasure")
        {

        }

        ///////// GRAVITY /////////
        else if (PlayerPrefs.GetString("GameMode") == "gravity")
        {

        }

        ///////// SNOOKER /////////
        else if (PlayerPrefs.GetString("GameMode") == "snooker")
        {

        }
    }
}
