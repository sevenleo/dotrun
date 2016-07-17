using UnityEngine;
using System.Collections;

public class fitsize : MonoBehaviour {
    public bool sprite=false;
    public bool colllider=false;
    public bool mesh=false;

    float width ;
    float height;

    float worldScreenHeight;
    float worldScreenWidth;



    void Start () {

        transform.localScale = new Vector3(1, 1, 1);

        if (sprite)
        {
            width = GetComponent<SpriteRenderer>().bounds.size.x;
            height = GetComponent<SpriteRenderer>().bounds.size.y;
        }

        if (colllider)
        {
            width = GetComponent<Collider2D>().bounds.size.x;
            height = GetComponent<Collider2D>().bounds.size.y;
        }


        if (mesh)
        {
            width = GetComponent<MeshRenderer>().bounds.size.x;
            height = GetComponent<MeshRenderer>().bounds.size.y;
        }



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
