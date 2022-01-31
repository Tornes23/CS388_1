using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImputManagerLogic : MonoBehaviour
{
    private Vector3 touch_position;
    public PlayerController player1;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.aspect = 1920f / 1080f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0) )
        {
            //Touch touch = Input.GetTouch(0);
            //Vector3 touch_position = Camera.main.ScreenToWorldPoint(touch.position);
            
            Vector3 touch_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            player1.GoToTarget(touch_position);
        }


    }
}
