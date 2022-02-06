using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    public float mSpeed = 0.1f;
    public float mChange = 0.1f;
    private Material mMat;
    // Start is called before the first frame update
    void Start()
    {
        mMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mMat.SetColor("_EmissionColor", HSBColor.ToColor(new HSBColor(Mathf.PingPong((Time.time + mChange) * mSpeed, 1), 1, 1)));
    }
}
