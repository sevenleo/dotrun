using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Display : MonoBehaviour {

    public GameObject player;
    public GameObject CirclePlayer;
    public GameObject _base;
    Vector3 mouseposition;
    Vector2 screen;

    // Use this for initialization
    void Start () {
        screen = new Vector3(Screen.width, Screen.height);

    }
	
	// Update is called once per frame
	void Update () {

        int specialnormalized = (status.special / status.defensevalue > 0) ? (int)(status.special / status.defensevalue) : 0;

        mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

        
        GetComponent<Text>().text =
            "\nTela = " + screen+
             "\nWorld = " + Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10)) +
            "\nMouse = " + mouseposition +
            "\nDistance mouse2player= " + Vector2.Distance(mouseposition, player.transform.position)+
            "\nSpecial = " + specialnormalized +
            "\nSpecialimit = " + status.speciallimit +
            "\nMaxEnemys = " + status.maxenemys +
            "\nEnemysSpeed = " + status.enemyspeed +
            "\nsecuredistance = " + status.securedistance +
            "\nscore = " + status.score +
            "\nGameMode = " + status.GameMode + 
            "\ngravity = " + status.gravity +
            "\nGodMode = " + status.GodMode
            ;

    }
}
