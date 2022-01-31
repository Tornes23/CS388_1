using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float epsilon = 0.01f;
    private float width;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        width = 1920f;
        height = 1080f;
    }

    public void GoToTarget(Vector3 target)
    {
        target.z = transform.position.z;

        DebugLog.DrawDebugText(target.ToString());

        if (Similar(target))
        {
            return;
        }

        float step = speed * Time.deltaTime;
        transform.Translate(Vector3.Normalize(target - transform.position) * step);
    }

    private bool Similar(Vector3 target)
    {
        Vector3 difference = (transform.position - target);
        if (
            Mathf.Abs(difference.x) > epsilon ||
            Mathf.Abs(difference.y) > epsilon
          )
        {
            return false;
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
