using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Transform Disk;
    // Start is called before the first frame update
    void Start()
    {
        Disk = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Disk.position;
    }

    public void SetColor(Color c)
    {
        var main = GetComponent<ParticleSystem>().main;
        main.startColor = c;
    }
}
