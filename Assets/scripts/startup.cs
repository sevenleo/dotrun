using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startup : MonoBehaviour
{

    float clicktime;
    float clickrate = 0.18f;
    bool doubleclick = false;

    void Start()
    {
        GameObject.Find("bestscore").GetComponent<Text>().text = GameObject.Find("bestscore").GetComponent<Text>().text + PlayerPrefs.GetInt("bestscore");
        clicktime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time < clicktime + clickrate) doubleclick = true;
            clicktime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetMouseButton(1) || Input.touches.Length >= 2 || doubleclick)
        {
            doubleclick = false;
            Save();
            SceneManager.LoadScene(PlayerPrefs.GetString("GameMode").ToLower());
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
        PlayerPrefs.SetInt("gravity", GameObject.Find("gravity").GetComponent<Toggle>().isOn? 1 : 0);
        PlayerPrefs.SetInt("GodMode", GameObject.Find("GodMode").GetComponent<Toggle>().isOn ? 1 : 0);
        PlayerPrefs.SetString("GameMode", GameObject.Find("GameMode").GetComponent<Dropdown>().captionText.text.ToLower());
    }

}