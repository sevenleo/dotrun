using UnityEngine;
using System.Collections;

public class enemys : MonoBehaviour {

    public GameObject enemy;
    float ControlTimeRate=0f;
    float ControlTime;
    public int HowMany=1;
    


    void Start () {
        ControlTime = Time.time + ControlTimeRate;
    }

    void Update()
    {
        HowMany = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (Time.time > ControlTime && HowMany < status.maxenemys && !status.wait)
        {
            ControlTime = Time.time + ControlTimeRate;
            Vector3 center = GameObject.FindGameObjectWithTag("Player").transform.position;

            Vector3 pos = RandomCircle(center, status.maxscreenside*status.securedistance, status.maxscreenside*status.securedistance*1.5f);
            //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }

    Vector3 RandomCircle(Vector3 center, float radiusmin, float radiusmax)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + Random.Range(radiusmin, radiusmax) * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + Random.Range(radiusmin, radiusmax) * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = 0*status.z;
        return pos;
    }

}
