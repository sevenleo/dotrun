using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{

    public Text P1status;
    public GameObject player;
    float cameradistance;
    Vector3 mouseposition;
    
    int z = 10;

    // Use this for initialization
    void Start()
    {
        status.special = 3f;
        cameradistance = -1f * transform.position.z;
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
        if (other.tag != "defense") SceneManager.LoadScene("startup");
    }
}
