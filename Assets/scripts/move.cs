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
            transform.position = mouseposition; 
        }
    }
}
