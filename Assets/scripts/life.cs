using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class life : MonoBehaviour {

    void Start()
    {
        transform.localScale = transform.localScale * status.ballsize;
    }



    void OnTriggerEnter2D(Collider2D other)
    {


        ///////// DOTRUN  /////////
        if (PlayerPrefs.GetString("GameMode") == "dotrun")
        {
            if (!status.GodMode && other.tag != "trail" && other.tag != "defense" && other.tag != "PlayerSprite")
            {
                SceneManager.LoadScene("startup");
            }
        }


        ///////// TREASURE  /////////
        else if (PlayerPrefs.GetString("GameMode") == "treasure")
        {
            if (!status.GodMode && other.tag != "trail" && other.tag != "defense" && other.tag != "PlayerSprite" && other.tag != "Player")
            {
                SceneManager.LoadScene("startup");
            }
        }


        ///////// TREASURE LIGHT /////////
        else if (PlayerPrefs.GetString("GameMode") == "treasurelight")
        {
            if (!status.GodMode && other.tag != "trail" && other.tag != "defense" && other.tag != "PlayerSprite" && other.tag != "Player")
            {
                SceneManager.LoadScene("startup");
            }
        }


        ///////// GRAVITY /////////
        else if (PlayerPrefs.GetString("GameMode") == "gravity")
        {
            if (!status.GodMode && other.tag != "trail" && other.tag != "defense" && other.tag != "base" && other.tag != "PlayerSprite")
            {
                SceneManager.LoadScene("startup");
            }
        }



        ///////// SNOOKER /////////
        else if (PlayerPrefs.GetString("GameMode") == "snooker")
        {


        }


      
    }
}
