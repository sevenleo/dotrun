using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class life : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if ( !status.GodMode && other.tag != "trail" && other.tag != "defense" && other.tag != "base" && other.tag != "PlayerSprite")
        {
            //Debug.LogError(other.name + " do tipo " + other.tag + " me matou");
            SceneManager.LoadScene("startup");
        }
    }
}
