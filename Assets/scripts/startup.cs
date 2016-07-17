using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startup : MonoBehaviour
{

    float clicktime;
    float clickrate = 0.18f;
    bool doubleclick = false;
    Color c,cdefault ;
    string t;

    void Start()
    {
        //GameObject.Find("bestscore").GetComponent<Text>().text = GameObject.Find("bestscore").GetComponent<Text>().text + PlayerPrefs.GetInt("bestscore");
        PlayerPrefs.SetString("GameMode", "startup");
        clicktime = Time.time;
        cdefault = GameObject.Find("CirclePlayer").GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerPrefs.SetString("GameMode", GameObject.Find("GameMode").GetComponent<Dropdown>().captionText.text.ToLower());

        switch (GameObject.Find("GameMode").GetComponent<Dropdown>().captionText.text.ToLower())
        {
            case "dotrun":
                t = "DOT RUN";
                c = cdefault;
                Camera.main.backgroundColor = new Color(0.0f, 0.0f, 0.1f, 1f);
                break;
            case "treasure":
                t = "* Treasure * ";
                break;
            case "gravity":
                t = "Gravity";
                c = Color.black;
                Camera.main.backgroundColor = new Color(0.4f, 0.4f, 0.4f, 1f);
                break;
            case "snooker":
                c = new Color(1f, 1f, 1f, 1f);
                t = "Sn00ker";
                Camera.main.backgroundColor = new Color(0f, 0.25f, 0.0f, 1f);
                break;
            default:
                break;
        }

        GameObject.Find("centertxt").GetComponent<Text>().text = t;
        GameObject.Find("centertxt").GetComponent<Text>().color = c;
        GameObject.Find("Text").GetComponent<Text>().color = c;
        GameObject.Find("CirclePlayer").GetComponent<SpriteRenderer>().color = c;





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
        PlayerPrefs.SetFloat("speciallimit", GameObject.Find("speciallimit").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("ballsize", GameObject.Find("ballsize").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("securedistance", GameObject.Find("securedistance").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("defensevalue", GameObject.Find("defensevalue").GetComponent<Slider>().value);
        //PlayerPrefs.SetInt("gravity", GameObject.Find("gravity").GetComponent<Toggle>().isOn? 1 : 0);
        PlayerPrefs.SetInt("GodMode", GameObject.Find("GodMode").GetComponent<Toggle>().isOn ? 1 : 0);
        PlayerPrefs.SetString("GameMode", GameObject.Find("GameMode").GetComponent<Dropdown>().captionText.text.ToLower());
    }

}