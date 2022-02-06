using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperLogic : MonoBehaviour
{

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
        if (tag == "Disk")
        {
            AudioSource.PlayClipAtPoint(BumperSound, transform.position);
        }
    }
}
