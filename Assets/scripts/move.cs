using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{

    public Text centertxt;
    public GameObject player;
    Vector3 mouseposition;
    
    int z = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,z);
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

        if (Input.GetMouseButton(0)  && Vector2.Distance(mouseposition, transform.position) > 0)
        {
            transform.position = mouseposition; 
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "defense" && other.tag != "base" && other.tag != "PlayerSprite")
        {
            Debug.LogError(other.name+" me matou");
            SceneManager.LoadScene("startup");
        }
    }
}
