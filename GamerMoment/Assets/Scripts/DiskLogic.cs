using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskLogic : MonoBehaviour
{
    public GameObject sp_point1;
    public GameObject sp_point2;
    public GameObject emitter;

    private bool mbRespawn;
    private bool mbZero;
    private Rigidbody2D mRB;
    private Transform mTransform;
    public float MaxSpeed = 20.0f;
    public float Scale = 0.75F;

    public AudioClip SparkSound;
    public AudioClip FoulSound;
    public AudioClip GoalSound;

    // Start is called before the first frame update
    void Start()
    {
        mRB = GetComponent<Rigidbody2D>();
        mTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(mbRespawn && !mbZero)
        {
            mTransform.localScale -= new Vector3(0.05F, 0.05F, 0.05F);
            mbZero = Mathf.Abs(mTransform.localScale.x - Scale) <= 0.01F;

            if (mbZero)
            {
                mTransform.localScale = new Vector3(Scale, Scale, Scale);
                mbRespawn = false;
                mbZero = true;
                GetComponent<CircleCollider2D>().enabled = true;

            }

        }    
        mRB.velocity = Vector3.ClampMagnitude(mRB.velocity, MaxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if(tag == "Goal1" || tag == "Goal2")
        {
            //make ball invisible 
            GetComponent<MeshRenderer>().enabled = false;
            //spawn at spawn point 
            transform.position = tag == "Goal1" ? sp_point1.transform.position : sp_point2.transform.position;
            mbRespawn = true;
            mbZero = false;
            mTransform.localScale *= 3;
            mRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = false;
            AudioSource.PlayClipAtPoint(GoalSound, transform.position);
        }

        if(tag == "Wall")
        {
            Vector2 contact_pos = collision.GetContact(0).point;
            Color c = collision.gameObject.GetComponent<MeshRenderer>().material.color;
            Instantiate(emitter).GetComponent<ParticleSpawner>().SpawnRipple(contact_pos, c);
            AudioSource.PlayClipAtPoint(SparkSound, transform.position);
        }

        if (tag == "Foul")
        {
            //make ball invisible 
            GetComponent<MeshRenderer>().enabled = false;
            Vector3 reset = new Vector3(0.0f, 0.0f, 0.0f);
            transform.position = reset;
            mRB.velocity = reset;
            GetComponent<MeshRenderer>().enabled = true;
            AudioSource.PlayClipAtPoint(FoulSound, transform.position);
        }
    }
}
