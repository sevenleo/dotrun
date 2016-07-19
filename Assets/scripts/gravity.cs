using UnityEngine;
using System.Collections;

public class gravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (status.score > status.goal)
        {
            status.maxenemys = status.maxenemys * 1.2f;
            status.goal = status.goal * 2;
            if (status.special < status.speciallimit) status.special *= 1.5f;
            status.securedistance *= 0.99f;
        }
    }
}
