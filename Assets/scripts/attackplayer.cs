using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class attackplayer : MonoBehaviour {

    GameObject player;
    Vector3 direction;
    Vector3 moveTo;
    float distance;
    int life = 1;
    int value = 1;

    
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (status.gravity) Destroy(gameObject, 5f);

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
        transform.position += Time.deltaTime * status.enemyspeed * direction;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "base":
                break;
            case "defense":
                life--;
                status.score += value;
                break;
            case "enemy":
                if (gameObject.GetHashCode() < other.GetHashCode())  {
                    Destroy(gameObject);
                }
                else   {
                    Destroy(other);
                    value *= 3;
                    transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.2f, 1.2f, 0));
                    //gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r * Random.Range(0, 1), GetComponent<SpriteRenderer>().color.g*Random.Range(0, 1), GetComponent<SpriteRenderer>().color.b*Random.Range(0, 1), GetComponent<SpriteRenderer>().color.a*Random.Range(0.5f, 1));
                }
                break;
            default:
                //Debug.Log("Colido com um" + other.tag+" chamado "+other.name);
                break;
        }
    }
}
