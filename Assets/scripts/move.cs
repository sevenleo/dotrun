using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class move : MonoBehaviour
{
    Vector3 screen;
    Vector3 mouseposition;


    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    Vector2 direction;
    Vector2 scale;



    void Start()
    {
        
        screen = new Vector3(Screen.width, Screen.height, status.z);
        //Debug.Log("Screen Pixels= " + screen);
        //Debug.Log("Screen Pixels Mag= " + screen.magnitude);
        screen = Camera.main.ScreenToWorldPoint(screen);
        //Debug.Log("Screen World = " + screen);
        //Debug.Log("Screen World Mag= " + screen.magnitude);

    }



    void Update()
    {



        mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, status.z);
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);


        //DOTRUN
        if (PlayerPrefs.GetString("GameMode") == "dotrun")
        {
            if (Input.GetMouseButton(0) && Vector2.Distance(mouseposition, transform.position) > 0)
            {
                transform.position = mouseposition;
            }

            if (Input.GetMouseButton(1))
            {
                transform.position = mouseposition;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            }
        }



        //GRAVITY
        else if (PlayerPrefs.GetString("GameMode") == "gravity")
        {
            if (Input.GetMouseButton(0) && Vector2.Distance(mouseposition, transform.position) > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.Lerp(transform.position, mouseposition, status.playerspeed / 10), ForceMode2D.Force);
            }

            if (GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            {
                SwipeMouse();
                //Swipe();
            }

        }



        //SNOOKER
        else if (PlayerPrefs.GetString("GameMode") == "snooker")
        {
            SwipeMouse();
            //Swipe();

            if (Input.GetMouseButton(1) && status.score==0)
            {
                transform.position = mouseposition;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            }
        }
 }



    /// <summary>
    // FUNCOES DE SWIPE COM O MOUSE OU COM O TOUCH
    /// </summary>

    public void SwipeMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            direction = currentSwipe;
            direction.Normalize();

            scale = secondPressPos - firstPressPos;
            
            float speed = scale.magnitude / screen.magnitude;
            GetComponent<Rigidbody2D>().AddForce(direction * speed * status.playerspeed, ForceMode2D.Impulse);
        }
    }



    void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                scale = secondPressPos - firstPressPos;

                float speed = scale.magnitude / screen.magnitude;
                GetComponent<Rigidbody2D>().AddForce(direction * speed * status.playerspeed, ForceMode2D.Impulse);
            }
        }
    }



    void TouchSimulator()
    {
        // Handle native touch events
        foreach (Touch touch in Input.touches)
        {
            HandleTouch(touch.fingerId, Camera.main.ScreenToWorldPoint(touch.position), touch.phase);
        }

        // Simulate touch events from mouse events
        if (Input.touchCount == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleTouch(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Began);
            }
            if (Input.GetMouseButton(0))
            {
                HandleTouch(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Moved);
            }
            if (Input.GetMouseButtonUp(0))
            {
                HandleTouch(10, Camera.main.ScreenToWorldPoint(Input.mousePosition), TouchPhase.Ended);
            }
        }
    }



    private void HandleTouch(int touchFingerId, Vector3 touchPosition, TouchPhase touchPhase)
    {
        switch (touchPhase)
        {
            case TouchPhase.Began:
                // TODO
                break;
            case TouchPhase.Moved:
                // TODO
                break;
            case TouchPhase.Ended:
                // TODO
                break;
        }
    }



}
