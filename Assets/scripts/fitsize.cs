using UnityEngine;
using System.Collections;

public class fitsize : MonoBehaviour {
    public bool w;
    public bool h;

    float width ;
    float height;

    float worldScreenHeight;
    float worldScreenWidth;



    void Start () {
        transform.localScale = new Vector3(1, 1, 1);

        width = GetComponent<Collider2D>().bounds.size.x;
        height = GetComponent<Collider2D>().bounds.size.y;

        worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height);
    }


    void reScaleSprite(SpriteRenderer sr)
    {
        
        if (sr == null) return;
        transform.localScale = new Vector3(1, 1, 1);

        width = sr.sprite.bounds.size.x;
        height = sr.sprite.bounds.size.y;

        worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height);
    }
}
