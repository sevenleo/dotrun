using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class myposition : MonoBehaviour {
    public Text me;
    Vector3 here;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        here =  Camera.main.ScreenToWorldPoint(  new Vector3(transform.position.x, transform.position.y, 0f)  );
        me.text = "I'm at " + here;
	}
}
