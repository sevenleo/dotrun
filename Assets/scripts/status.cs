using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class status : MonoBehaviour {
    public GameObject specialbar;
    static public float speciallimit { get; set; }
    static public float special { get; set; }
    static public int score { get; set; }
    static public float securedistance { get; set; }
    static public float maxenemys { get; set; }
    static public float enemyspeed { get; set; }
    static public bool wait;
    int goal;

    void Start()
    {
        speciallimit=17f;
        enemyspeed = 1.5f;
        maxenemys = 5;
        securedistance = 2f;
        wait = false;
        special = 5;
        score = 0;
        goal = 5;
    }
    void Update()
    {

        if (special > 0) specialbar.transform.localScale = new Vector3(special / 17f, 1f, 1f);
        else specialbar.transform.localScale = Vector3.zero;

        special += Time.deltaTime;
        
        GameObject.Find("centertxt").GetComponent<Text>().text = "" + (int)status.score;
        if (score > goal)
        {
            maxenemys = maxenemys * 1.5f;
            goal = goal * 2;
            if (special < speciallimit) special *= 1.5f;
            securedistance *= 0.99f;
        }
    }
}
