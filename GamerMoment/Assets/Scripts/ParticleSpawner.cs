using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public float max_time;
    ParticleSystem emitter;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<ParticleSystem>();
        emitter.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > max_time)
        {
            emitter.Stop();
        }
        if(emitter.isPlaying)
        {
            timer += Time.deltaTime;
        }
    }

    public void SpawnRipple(Vector2 pos, Color c)
    {
        emitter.Play();
        timer = 0.0F;
    }
}
