using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gravity : MonoBehaviour {


    public GameObject reward;
    
    void Start () {
        status.special = 0;
        Instantiate<GameObject>(reward);
    }
	
	void Update () {
        if (status.score > status.goal)
        {
            Instantiate<GameObject>(reward);
            status.maxenemys = status.maxenemys * 1.2f;
            status.securedistance *= 0.99f;
            status.goal += status.score;
        }
        if (Vector3.Distance(gameObject.transform.position,Vector3.zero) > status.maxscreenside*5)
        {
            SceneManager.LoadScene("startup");
        }
    }


    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "reward")
        {
            status.special++;
            status.score++;
            Destroy(collisionInfo.gameObject);
            Instantiate<GameObject>(reward);

        }
    }
}
