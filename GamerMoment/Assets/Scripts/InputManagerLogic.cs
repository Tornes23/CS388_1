using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerLogic : MonoBehaviour
{
    private Vector3 touch_position;
    private Rect left_screen;
    private Rect right_screen;

    public PlayerController player1;
    public PlayerController player2;

    public bool mbGameFinished;

    // Start is called before the first frame update
    void Start()
    {
        mbGameFinished = false;
        left_screen = new Rect(0, 0, (Screen.width / 2), Screen.height);
        right_screen = new Rect((Screen.width / 2), 0, (Screen.width / 2), Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        if (mbGameFinished == true)
            return;

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
            if (player2 != null && right_screen.Contains(touch_position) && !p2_moved)
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
            if (player2 != null && right_screen.Contains(touch_position) && !p2_moved)
            {
                player2.GoToTarget(Camera.main.ScreenToWorldPoint(touch_position));
                p2_moved = true;
            }
        }


        //BUTTONS
        //Player 1
        if (Input.GetKey(KeyCode.W))
        {
            player1.MoveUP();
        }
        if (Input.GetKey(KeyCode.A))
        {
            player1.MoveLEFT();
        }
        if (Input.GetKey(KeyCode.S))
        {
            player1.MoveDOWN();
        }
        if (Input.GetKey(KeyCode.D))
        {
            player1.MoveRIGHT();
        }
        //Player 2
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player2.MoveUP();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player2.MoveLEFT();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player2.MoveDOWN();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player2.MoveRIGHT();
        }
    }

    public void EndGame(bool set) { mbGameFinished = set; }
}
