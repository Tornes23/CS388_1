using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mSpeed = 10;
    public float mEpsilon = 0.01f;
    private Rigidbody2D mRB;

    public Transform mBound;
    private Boundary mPlayerBoundarys;

    struct Boundary
    { 
        public float mUp, mDown, mLeft, mRight;

        public Boundary(float up, float down, float left, float right)
        {
            mUp = up;
            mDown = down;
            mLeft = left;
            mRight = right;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mRB = GetComponent<Rigidbody2D>();

        mPlayerBoundarys = new Boundary(
                                            mBound.GetChild(0).position.y,
                                            mBound.GetChild(1).position.y,
                                            mBound.GetChild(2).position.x,
                                            mBound.GetChild(3).position.x
                                       );
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

        Vector2 clamed_target = new Vector2(Mathf.Clamp(target.x, mPlayerBoundarys.mLeft, mPlayerBoundarys.mRight),
                                     Mathf.Clamp(target.y, mPlayerBoundarys.mDown, mPlayerBoundarys.mUp));

        //compute the step and move towards teh target
        float step = mSpeed * Time.deltaTime;
        //dir = target - transform.position;
        //transform.Translate(Vector3.Normalize(dir * step));
        //transform.Translate(Vector3.Normalize((target - transform.position)) * step);
        mRB.MovePosition(clamed_target);
    }

    private bool Similar(Vector3 target)
    {
        Vector3 difference = (transform.position - target);
        if (
            Mathf.Abs(difference.x) > mEpsilon ||
            Mathf.Abs(difference.y) > mEpsilon
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
