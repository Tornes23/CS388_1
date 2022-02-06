using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskLogic : MonoBehaviour
{
    public GameObject sp_point1;
    public GameObject sp_point2;
    public ParticleSpawner prt_emitter;

    public AudioClip BumperSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
            GetComponent<MeshRenderer>().enabled = true;
        }

        if(tag == "Wall")
        {
            Vector2 contact_pos = collision.GetContact(0).point;
            Color c = collision.gameObject.GetComponent<MeshRenderer>().material.color;
            prt_emitter.SpawnRipple(contact_pos, c);
        }

        if (tag == "Bumper")
        {
            AudioSource.PlayClipAtPoint(BumperSound, transform.position);
        }
    }
}
