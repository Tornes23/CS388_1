using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float mSpeed = 10;
    private Vector2 mStartingPos;
    private Rigidbody2D mRB;

    public Rigidbody2D mDisk;

    public Transform mAiBound;
    private PlayerController.Boundary mAIBoundarys;

    public Transform mDiskBound;
    private PlayerController.Boundary mDiskBoundarys;

    private Vector2 mTarget;

    public AudioClip BonkSound;

    // Start is called before the first frame update
    void Start()
    {
        mRB = GetComponent<Rigidbody2D>();

        mStartingPos = mRB.position;

        mAIBoundarys = new PlayerController.Boundary(
                                            mAiBound.GetChild(0).position.y,
                                            mAiBound.GetChild(1).position.y,
                                            mAiBound.GetChild(2).position.x,
                                            mAiBound.GetChild(3).position.x
                                       );

        mDiskBoundarys = new PlayerController.Boundary(
                                            mDiskBound.GetChild(0).position.y,
                                            mDiskBound.GetChild(1).position.y,
                                            mDiskBound.GetChild(2).position.x,
                                            mDiskBound.GetChild(3).position.x
                                       );
    }

    private void FixedUpdate()
    {
        float speed;

        if (mDisk.position.x < mDiskBoundarys.mLeft)
        {
            speed = mSpeed * Random.Range(0.1f, 0.3f);

            mTarget = new Vector2(mStartingPos.x,
                                  Mathf.Clamp(mDisk.position.y, mAIBoundarys.mDown, mAIBoundarys.mUp));

        }
        else
        {
            speed = mSpeed * Random.Range(mSpeed * 0.4f, mSpeed);
            mTarget = new Vector2(Mathf.Clamp(mDisk.position.x, mAIBoundarys.mLeft, mAIBoundarys.mRight),
                                  Mathf.Clamp(mDisk.position.y, mAIBoundarys.mDown, mAIBoundarys.mUp));
        }

        mRB.MovePosition(Vector2.MoveTowards(mRB.position, mTarget, mSpeed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Disk")
        {
            AudioSource.PlayClipAtPoint(BonkSound, transform.position);
        }
    }
}
