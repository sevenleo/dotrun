using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class attackplayer : MonoBehaviour {

    GameObject player;
    GameObject treasure;
    Vector3 direction;
    Vector3 moveTo;
    float distance;
    int life = 1;
    int value = 1;


    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        treasure = GameObject.FindGameObjectWithTag("treasure");
        transform.localScale = transform.localScale * status.ballsize;

    }


    void Update()
    {
        ///////// DOTRUN  /////////
        if (PlayerPrefs.GetString("GameMode") == "dotrun")
        {
            if (life <= 0) Destroy(gameObject);

            moveTo = player.transform.position - transform.position;


            distance = moveTo.magnitude;
            direction = moveTo / distance;
            transform.position += Time.deltaTime * status.enemyspeed * direction;
        }


        ///////// TREASURE  /////////
        else if (PlayerPrefs.GetString("GameMode") == "treasure")
        {
            if (life <= 0) Destroy(gameObject);

            moveTo = treasure.transform.position - transform.position;

            distance = moveTo.magnitude;
            direction = moveTo / distance;
            transform.position += Time.deltaTime * status.enemyspeed * direction;
        }


        ///////// GRAVITY /////////
        else if (PlayerPrefs.GetString("GameMode") == "gravity")
        {
            Destroy(gameObject, 10f);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            if (life <= 0) Destroy(gameObject);

            moveTo = player.transform.position - transform.position;

            distance = moveTo.magnitude;
            direction = moveTo / distance;
            transform.position += Time.deltaTime * status.enemyspeed * direction;
        }



        ///////// SNOOKER /////////
        else if (PlayerPrefs.GetString("GameMode") == "snooker")
        {


        }
    }






    void OnTriggerEnter2D(Collider2D other)
    {

        ///////// DOTRUN  /////////
        if (PlayerPrefs.GetString("GameMode") == "dotrun")
            {
                switch (other.tag)
                {
                    case "defense":
                        life--;
                        status.score += value;
                        break;
                    case "trail":
                        life--;
                        status.score += value;
                        break;
                    case "enemy":
                        if (gameObject.GetHashCode() < other.GetHashCode())
                        {
                            Destroy(gameObject);
                        }
                        else
                        {
                            Destroy(other);
                            value *= 3;
                            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.2f, 1.2f, 0));
                        }
                        break;
                    default:
                        break;
                }
        }

            ///////// TREASURE  /////////
            else if (PlayerPrefs.GetString("GameMode") == "treasure")
            {
                switch (other.tag)
                {
                case "Player":
                    life--;
                    status.score += value;
                    status.special += 0.05f;
                    Destroy(gameObject);
                    break;
                case "defense":
                        life--;
                        status.score += value;
                        status.special += 0.05f;
                        break;
                    case "trail":
                        life--;
                        status.score += value;
                        status.special += 0.05f;
                    break;
                    /*case "enemy":
                    if (gameObject.GetHashCode() < other.GetHashCode())
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        Destroy(other);
                        value *= 3;
                        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.2f, 1.2f, 0));
                        //gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r * Random.Range(0, 1), GetComponent<SpriteRenderer>().color.g*Random.Range(0, 1), GetComponent<SpriteRenderer>().color.b*Random.Range(0, 1), GetComponent<SpriteRenderer>().color.a*Random.Range(0.5f, 1));
                    }
                    break;*/
                    case "treasure":
                        status.score = 0;
                        SceneManager.LoadScene("startup");
                        break;
                    default:
                        break;
                }
             }

            ///////// GRAVITY /////////
            else if (PlayerPrefs.GetString("GameMode") == "gravity")
            {
            switch (other.tag)
            {
                case "defense":
                    life--;
                    status.score += value;
                    break;
                case "trail":
                    life--;
                    status.score += value;
                    break;
                case "enemy":
                    if (gameObject.GetHashCode() < other.GetHashCode())
                    {
                        Destroy(gameObject);
                    }
                    break;
                default:
                    break;
            }
        }

            ///////// SNOOKER /////////
            else if (PlayerPrefs.GetString("GameMode") == "snooker")
            {

            }
    }


}
