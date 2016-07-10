using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startup : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetMouseButton(1) || Input.touches.Length >= 2))
            SceneManager.LoadScene("scene");

    }
}