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
    float impact = 20.0f;
    bool collided = false;
    int life = 1;
    int value = 1;
    float delay = 0.2f;


    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        treasure = GameObject.FindGameObjectWithTag("treasure");
        //transform.localScale = transform.localScale * status.ballsize;

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

        ///////// TREASURE LIGHT /////////
        else if (PlayerPrefs.GetString("GameMode") == "treasurelight")
        {
            if (life <= 0) Destroy(gameObject,delay);

            GameObject target = treasure;

            GameObject[] treasures = GameObject.FindGameObjectsWithTag("treasure");
            float distance = 1000f;

            foreach (GameObject treasure in treasures)
            {
                float d = Vector3.Distance(this.transform.position, treasure.transform.position);
                if ( d < distance) {
                    distance=d;
                    target = treasure;
                }

            }
    
            if (collided){

            }
            else {
                moveTo = target.transform.position - transform.position;

                distance = moveTo.magnitude;
                direction = moveTo / distance;
                transform.position += Time.deltaTime * status.enemyspeed * direction;
            }
        }


        ///////// GRAVITY /////////
        else if (PlayerPrefs.GetString("GameMode") == "gravity")
        {
            Destroy(gameObject, Random.Range(10,30));
            GetComponent<Rigidbody2D>().gravityScale = 0f;
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
                    GetComponent<AudioSource>().Play();
                    //Destroy(gameObject);
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

            ///////// TREASURE LIGHT /////////
            else if (PlayerPrefs.GetString("GameMode") == "treasurelight")
            {
                switch (other.tag)
                {
                case "Player":
                    collided = true;
                    life--;
                    status.score += value;
                    status.special += 0.05f;
                    GetComponent<AudioSource>().Play();
                    Vector3 dir = other.transform.position - transform.position;
                    dir = -dir.normalized;
                    GetComponent<Rigidbody2D>().AddForce(dir * impact, ForceMode2D.Impulse);
                    other.GetComponent<Rigidbody2D>().AddForce(Vector2.zero, ForceMode2D.Impulse);
                    //Destroy(gameObject);
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
