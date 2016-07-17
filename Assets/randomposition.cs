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

        randx = Random.Range(screen.x * 0.2f, screen.x*0.8f);
        randy = Random.Range(screen.y * 0.2f, screen.y*0.8f);

        go.transform.position = new Vector3(randx, randy, 0);
        go.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        go.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
        go.GetComponentInChildren<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
    }
}
