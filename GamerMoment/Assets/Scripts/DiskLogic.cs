using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskLogic : MonoBehaviour
{
    public GameObject sp_point1;
    public GameObject sp_point2;
    public ParticleSpawner prt_emitter;

    private Rigidbody2D mRB;
    public float MaxSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        mRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        mRB.velocity = Vector3.ClampMagnitude(mRB.velocity, MaxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if(tag == "Goal1" || tag == "Goal2")
        {
            //make ball invisible 
            GetComponent<MeshRenderer>().enabled = false;
            ////particle effect think about how to implement
            //transform.position = tag == "Goal1" ? sp_point1.transform.position : sp_point2.transform.position;
            //spawn at spawn point 
            transform.position = tag == "Goal1" ? sp_point1.transform.position : sp_point2.transform.position;
            mRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            GetComponent<MeshRenderer>().enabled = true;
        }

        if(tag == "Wall")
        {
            Vector2 contact_pos = collision.GetContact(0).point;
            Color c = collision.gameObject.GetComponent<MeshRenderer>().material.color;
            prt_emitter.SpawnRipple(contact_pos, c);
        }

        if (tag == "Foul")
        {
            //make ball invisible 
            GetComponent<MeshRenderer>().enabled = false;
            Vector3 reset = new Vector3(0.0f, 0.0f, 0.0f);
            transform.position = reset;
            mRB.velocity = reset;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
