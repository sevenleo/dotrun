using UnityEngine;
using System.Collections;

public class textattach : MonoBehaviour {

    public GameObject obj;

	
	void Update () {
        
        transform.position = Camera.main.WorldToScreenPoint( new Vector3 (obj.transform.position.x, obj.transform.position.y, 0));
        
        transform.rotation = obj.transform.rotation;
    }
}
