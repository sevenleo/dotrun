﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class snooker : MonoBehaviour {



    // Use this for initialization
    void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
	
	// Update is called once per frame
	void Update () {
        if ( Vector3.Distance(gameObject.transform.position, Vector3.zero) > status.maxscreenside*3)
            SceneManager.LoadScene("startup"); 
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "cacapa")
        {
            if (gameObject.name == "Player") {
                status.score = 0;
                gameObject.transform.position = Vector3.zero;
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            } 


            else if (gameObject.name == "Player2")
            {
                collisionInfo.gameObject.GetComponent<AudioSource>().Play();
                status.score += 1;
                randomposition.RandomColorAndposition(gameObject);
            }
        }
    }



}
