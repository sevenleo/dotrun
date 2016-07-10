using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class status : MonoBehaviour {

    static public float special { get; set; }

    void Update()
    {
        special += Time.deltaTime;
        GameObject.Find("P1status").GetComponent<Text>().text = "" + (int)status.special;
    }
}
