using UnityEngine;
using System.Collections;

public class treasure : MonoBehaviour {

    
    public GameObject treasure0;

    void Start()
    {
        status.special = 0;
    }

    void Update () {

        if (status.score >= status.goal)
        {
            Instantiate<GameObject>(treasure0);
            status.maxenemys = status.maxenemys * 1.2f;
            status.securedistance *= 0.99f;
            status.goal += status.score;
        }


    }
}
