using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    ParticleSystem emitter;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnRipple(Vector2 pos, Color c)
    {
        GetComponent<ParticleSystem>().Play();
        var main = GetComponent<ParticleSystem>().main;
        main.startColor = c;
        transform.position = new Vector3(pos.x, pos.y, -2.0F);
    }
}
