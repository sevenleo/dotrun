using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{

    Vector3 mouseposition;

    void Start()
    {
        if (status.gravity) GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (status.gravity) GetComponent<Rigidbody2D>().gravityScale = 1;

        mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,status.z);
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

        if (Input.GetMouseButton(0)  && Vector2.Distance(mouseposition, transform.position) > 0)
        {

                if (PlayerPrefs.GetString("GameMode") == "dotrun")
                {
                     transform.position = mouseposition;
                }
                else if (PlayerPrefs.GetString("GameMode") == "gravity")
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.Lerp(transform.position, mouseposition, status.playerspeed / 10), ForceMode2D.Force);

                }
            else if (PlayerPrefs.GetString("GameMode") == "snooker")
                {
                     GetComponent<Rigidbody2D>().AddForce(Vector2.Lerp(transform.position, mouseposition, status.playerspeed / 100), ForceMode2D.Force);

                     if (Input.GetKeyDown(KeyCode.W))
                        GetComponent<Rigidbody2D>().AddForce(Vector2.up * status.playerspeed/100, ForceMode2D.Impulse);
                     if (Input.GetKeyDown(KeyCode.S))
                        GetComponent<Rigidbody2D>().AddForce(Vector2.down * status.playerspeed / 100, ForceMode2D.Impulse);
                     if (Input.GetKeyDown(KeyCode.A))
                        GetComponent<Rigidbody2D>().AddForce(Vector2.left * status.playerspeed / 100, ForceMode2D.Impulse);
                     if (Input.GetKeyDown(KeyCode.D))
                        GetComponent<Rigidbody2D>().AddForce(Vector2.right * status.playerspeed / 100, ForceMode2D.Impulse);
                }
        }



    }
}
