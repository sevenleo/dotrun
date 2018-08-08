using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startup : MonoBehaviour
{
    public GameObject player;
    float clicktime;
    float clickrate = 0.18f;
    bool doubleclick = false;
    Color playercolor,bgcolor,cdefault ;
    string title;
    int best;

    void Start()
    {
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.orientation = ScreenOrientation.AutoRotation;

        PlayerPrefs.SetString("GameMode", "startup");
        clicktime = Time.time;
        cdefault = GameObject.Find("CirclePlayer").GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.localScale = new Vector3(GameObject.Find("ballsize").GetComponent<Slider>().value, GameObject.Find("ballsize").GetComponent<Slider>().value, GameObject.Find("ballsize").GetComponent<Slider>().value);
        switch (GameObject.Find("GameMode").GetComponent<Dropdown>().captionText.text.ToLower())
        {
            case "dotrun":
                title = "DOT RUN";
                playercolor = cdefault;
                bgcolor = new Color(0.0f, 0.0f, 0.1f, 1f);
                best = PlayerPrefs.GetInt("bestscore_dotrun");
                PlayerPrefs.SetString("GameMode", "dotrun");
                break;
            case "treasure":
                title = "Trea$ure";
                playercolor = new Color(0.8f, 0.8f, 0.8f, 1f); ;
                bgcolor = new Color(0.0f, 0.0f, 0.0f, 1f);
                best = PlayerPrefs.GetInt("bestscore_treasure");
                PlayerPrefs.SetString("GameMode", "treasure");
                break;
            case "treasurelight":
                title = "Treasure: *Light*";
                playercolor = new Color(0.0f, 0.0f, 0.0f, 1f); ;
                bgcolor = new Color(1.0f, 1.0f, 1.0f, 1f);
                best = PlayerPrefs.GetInt("bestscore_treasurelight");
                PlayerPrefs.SetString("GameMode", "treasurelight");
                break;
            case "gravity":
                title = "Gravity";
                playercolor = Color.black;
                best = PlayerPrefs.GetInt("bestscore_gravity");
                bgcolor = new Color(0.4f, 0.4f, 0.4f, 1f);
                PlayerPrefs.SetString("GameMode", "gravity");
                break;
            case "snooker":
                playercolor = new Color(1f, 1f, 1f, 1f);
                title = "Sn00ker";
                best = PlayerPrefs.GetInt("bestscore_snooker");
                bgcolor = new Color(0f, 0.25f, 0.0f, 1f);
                PlayerPrefs.SetString("GameMode", "snooker");
                break;
            default:
                break;
        }

        Camera.main.backgroundColor = bgcolor;
        GameObject.Find("bestscore").GetComponent<Text>().text = "Best: "+best;
        GameObject.Find("centertxt").GetComponent<Text>().text = title;
        GameObject.Find("centertxt").GetComponent<Text>().color = playercolor;
        GameObject.Find("Text").GetComponent<Text>().color = playercolor;
        GameObject.Find("CirclePlayer").GetComponent<SpriteRenderer>().color = playercolor;
        foreach ( Slider sl in FindObjectsOfType<Slider>())
        {
            sl.GetComponent<Slider>().colors = new ColorBlock();
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time < clicktime + clickrate) doubleclick = true;
            clicktime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.touches.Length >= 2 || doubleclick)
        {
            doubleclick = false;
            Save();
            SceneManager.LoadScene(GameObject.Find("GameMode").GetComponent<Dropdown>().captionText.text.ToLower());
        }

    }

    void Save()
    {

        PlayerPrefs.SetFloat("traillife", GameObject.Find("traillife").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("maxenemys", GameObject.Find("maxenemys").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("enemyspeed", GameObject.Find("enemyspeed").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("special", GameObject.Find("special").GetComponent<Slider>().value);
        PlayerPrefs.SetInt("goal", (int)GameObject.Find("goal").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("speciallimit", GameObject.Find("speciallimit").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("ballsize", GameObject.Find("ballsize").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("securedistance", GameObject.Find("securedistance").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("defensevalue", GameObject.Find("defensevalue").GetComponent<Slider>().value);
        //PlayerPrefs.SetInt("gravity", GameObject.Find("gravity").GetComponent<Toggle>().isOn? 1 : 0);
        PlayerPrefs.SetInt("GodMode", GameObject.Find("GodMode").GetComponent<Toggle>().isOn ? 1 : 0);
        PlayerPrefs.SetInt("debug", GameObject.Find("debug").GetComponent<Toggle>().isOn ? 1 : 0);
        PlayerPrefs.SetString("GameMode", GameObject.Find("GameMode").GetComponent<Dropdown>().captionText.text.ToLower());

        status.bgcolor = bgcolor;
        status.playercolor = playercolor;
    }

    public void Quit()
    {
        Application.Quit();
    }
}