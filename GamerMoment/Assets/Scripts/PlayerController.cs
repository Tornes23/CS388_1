using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float epsilon = 0.01f;
    Rigidbody2D rb;
    //Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //The function that tells the player where to go
    public void GoToTarget(Vector3 target)
    {
        //this its so we ignotre the z
        target.z = transform.position.z;

        //check if the positions are similar enough
        if (Similar(target))
        {
            return;
        }

        //compute the step and move towards teh target
        float step = speed * Time.deltaTime;
        //dir = target - transform.position;
        //transform.Translate(Vector3.Normalize(dir * step));
        //transform.Translate(Vector3.Normalize((target - transform.position)) * step);
        rb.MovePosition(target);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ContactPoint2D contact = collision.GetContact(0);
        //
        //if(collision.gameObject.tag == "Disk")
        //{
        //    float dot = Vector2.Dot(dir, contact.normal);
        //
        //}
    }
}
