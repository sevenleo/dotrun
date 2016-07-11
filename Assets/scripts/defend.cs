using UnityEngine;
using System.Collections;

public class defend : MonoBehaviour {

    public GameObject sphere_prefab;
    GameObject sphere;
    bool launched = false;
    public float firerate = 0.2f;
    float nextfire;
    float clicktime;
    float clickrate = 0.18f;
    bool doubleclick = false;
    float range;

    void Start () {
        clicktime = Time.time;
        nextfire = Time.time + firerate;
    }
	
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time < clicktime + clickrate && status.special>0) doubleclick = true;
            clicktime = Time.time;
        }

       
        if ((Input.GetMouseButton(1) || Input.touches.Length>=2 || doubleclick) && Time.time>nextfire && status.special > 0)
        {
            doubleclick = false;
            GetComponent<AudioSource>().Play();
            nextfire = Time.time + firerate;
            sphere = Instantiate<GameObject>(sphere_prefab);
            sphere.transform.position = transform.position;
            sphere.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            launched = true;
            status.wait = true;
            status.special -= status.defensevalue;
            range = status.maxscreenside * (status.special / status.speciallimit);
            Debug.Log("max " + status.maxscreenside);
            Debug.Log("sp " + status.special);
            Debug.Log("spl " + status.speciallimit);
            Debug.Log("range " + range);
        }

        if (sphere == null)
        {
            launched = false;
            status.wait = false;

        }
        else if (launched )
        {   
            
            if (sphere.transform.localScale.x<range) sphere.transform.localScale = Vector3.Scale(sphere.transform.localScale, new Vector3(1.1f, 1.1f, 0));
            sphere.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.95f * sphere.GetComponent<Renderer>().material.color.a);
            Destroy(sphere, 1);
        }
    }
}
