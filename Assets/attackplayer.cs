using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class attackplayer : MonoBehaviour {

    GameObject player;
    float speed = 3f;
    Vector3 direction;
    Vector3 moveTo;
    float distance;
    int life = 1;

    
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //Destroy(gameObject, 5f);
        if (life <= 0) Destroy(gameObject);

        if (gameObject.tag == "texto") {
            moveTo = player.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, transform.position.y, 0f));
        }
        else
        {
            moveTo = player.transform.position - transform.position;
        }

        distance = moveTo.magnitude;
        direction = moveTo / distance;
        transform.position += Time.deltaTime * speed * direction;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "enemy")
        {
            life--;
        }
        else {
            if (gameObject.GetHashCode() > other.GetHashCode())
                Destroy(gameObject);
            else {
                Destroy(other);
                life++;
                transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.5f, 1.5f, 0));
            }
                
        }

    }
}
