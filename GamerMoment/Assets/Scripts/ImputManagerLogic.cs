using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImputManagerLogic : MonoBehaviour
{
    private Vector3 touch_position;
    private Rect left_screen;
    private Rect right_screen;

    public PlayerController player1;
    public PlayerController player2;

    // Start is called before the first frame update
    void Start()
    {
        //
        //Camera.main.aspect = 1920f / 1080f;
        //save the rectangles of where we can touch
        left_screen = new Rect(0, 0, (Screen.width / 2), Screen.height);
        right_screen = new Rect((Screen.width / 2), 0, (Screen.width / 2), Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        bool p1_moved = false;
        bool p2_moved = false;
        
        //check if there its any imput
        for (int i = 0; i < Input.touchCount; ++i)
        {
            //Touche Controls
            Touch touch = Input.GetTouch(i);
            touch_position = touch.position;

            //check if we are touching on  the left side of the screen
            if (left_screen.Contains(touch_position) && !p1_moved)
            {
                player1.GoToTarget(Camera.main.ScreenToWorldPoint(touch_position));
                p1_moved = true;
            }

            //check if we are touching on the right side of the screen
            if (right_screen.Contains(touch_position) && !p2_moved)
            {
                player2.GoToTarget(Camera.main.ScreenToWorldPoint(touch_position));
                p2_moved = true;
            }
        }

        //DELETE
        //Mouce Controls (used for debugging purposes)
        if (Input.GetMouseButton(0))
        {
            touch_position = Input.mousePosition;

            //check if we are touching on  the left side of the screen
            if (left_screen.Contains(touch_position) && !p1_moved)
            {
                player1.GoToTarget(Camera.main.ScreenToWorldPoint(touch_position));
                p1_moved = true;
            }

            //check if we are touching on the right side of the screen
            if (right_screen.Contains(touch_position) && !p2_moved)
            {
                player2.GoToTarget(Camera.main.ScreenToWorldPoint(touch_position));
                p2_moved = true;
            }
        }
    }
}
