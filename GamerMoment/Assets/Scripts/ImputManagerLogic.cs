using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImputManagerLogic : MonoBehaviour
{
    private Vector3 touch_position;
    private float width;
    private float height;

    public Transform player1;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.aspect = 1920f / 1080f;
        width = 1920f / 2;
        height = 1080f / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touch_position = Camera.main.ScreenToWorldPoint(touch.position);

            touch_position.z = player1.position.z;

            DebugLog.DrawDebugText(touch_position.ToString());

            float step = speed * Time.deltaTime;
            player1.Translate(Vector3.Normalize(touch_position - player1.position) * step);
        }


    }
}
