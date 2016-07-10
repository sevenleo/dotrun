using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Display : MonoBehaviour {

    public GameObject player;
    public GameObject CirclePlayer;
    public GameObject _base;
    Vector3 mouseposition;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

        GetComponent<Text>().text =
            "Mouse = " + mouseposition +
            "\nbase = " + _base.transform.position+
            "\nPlayerClass = " + player.transform.position +
            "\nCirclePlayer = " + CirclePlayer.transform.position +
            "\nDistance = " + Vector2.Distance(mouseposition, player.transform.position);
    }
}
