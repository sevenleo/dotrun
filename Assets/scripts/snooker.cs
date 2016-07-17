using UnityEngine;
using System.Collections;

public class snooker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "cacapa")
        {
            if (gameObject.name == "Player") {
                status.score = 0;
            } 


            else if (gameObject.name == "Player2")
            {
                status.score += 1;
                randomposition.RandomColorAndposition(gameObject);
            }
        }
    }



}
