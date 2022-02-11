using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalParticles : MonoBehaviour
{
    ParticleSystem emitter;
    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<ParticleSystem>();
        emitter.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        var shape = emitter.shape;
        if (shape.radius >= 0.1)
            shape.radius -= 5 * Time.deltaTime;
        else
            emitter.Stop();
    }
    public void GoalVFX()
    {
        emitter.Play();
        var shape = emitter.shape;
        shape.radius = 15.0F;
    }
}
