using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float epsilon = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
    }

    //The function that tells the player where to go
    public void GoToTarget(Vector3 target)
    {
        //this its so we ignotre the z
        target.y = transform.position.y;

        //check if the positions are similar enough
        if (Similar(target))
        {
            return;
        }

        //compute the step and move towards teh target
        float step = speed * Time.deltaTime;
        transform.Translate(Vector3.Normalize(target - transform.position) * step);
    }

    private bool Similar(Vector3 target)
    {
        Vector3 difference = (transform.position - target);
        if (
            Mathf.Abs(difference.x) > epsilon ||
            Mathf.Abs(difference.z) > epsilon
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
