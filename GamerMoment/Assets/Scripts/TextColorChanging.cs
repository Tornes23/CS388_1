using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChanging : MonoBehaviour
{
    public float mSpeed = 0.1f;
    public float mChange = 0.1f;
    private Text mText;
    // Start is called before the first frame update
    void Start()
    {
        mText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        mText.color = HSBColor.ToColor(new HSBColor(Mathf.PingPong((Time.time + mChange) * mSpeed, 1), 1, 1));
    }
}
