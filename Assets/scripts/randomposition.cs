using UnityEngine;
using System.Collections;

public class randomposition : MonoBehaviour {



    public void Start () {

        RandomColorAndposition(gameObject);

    }
	
	void Update () {
	
	}

    public static void RandomColorAndposition(GameObject go)
    {
        
        Vector3 screen;
        float randx, randy;

        screen = new Vector3(Screen.width, Screen.height, status.z);
        screen = Camera.main.ScreenToWorldPoint(screen);

        randx = Random.Range(-screen.x , screen.x);
        randy = Random.Range(-screen.y * 0.65f, screen.y*0.65f);

        go.transform.position = new Vector3(randx, randy, 0);
        go.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        go.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
        go.GetComponentInChildren<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
    }
}
