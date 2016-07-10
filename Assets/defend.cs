using UnityEngine;
using System.Collections;

public class defend : MonoBehaviour {

    public GameObject sphere_prefab;
    GameObject sphere;
    bool launched = false;
    public float firerate = 0.2f;
    float nextfire;
    void Start () {
        nextfire = Time.time + firerate;
    }
	
	void Update () {
        
        if ((Input.GetMouseButton(1) || Input.touches.Length>=2) && Time.time>nextfire)
        {
            nextfire = Time.time + firerate;
            sphere = Instantiate<GameObject>(sphere_prefab);
            sphere.transform.position = transform.position;
            //sphere.GetComponent<Renderer>().material.color = new Color(1f,1f,1f,1f);
            sphere.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            launched = true;
            status.special -= firerate;
        }

        if (sphere == null) launched = false;
        else if (launched && status.special>0)
        {
            Destroy(sphere, 1);
            sphere.transform.localScale = Vector3.Scale(sphere.transform.localScale, new Vector3(1.1f, 1.1f, 0));
            sphere.GetComponent<Renderer>().material.color =  new Color(1f, 1f, 1f, 0.95f * sphere.GetComponent<Renderer>().material.color.a);
        }
    }
}
