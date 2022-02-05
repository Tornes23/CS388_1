using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text score;
    int goals;
    // Start is called before the first frame update
    void Start()
    {
        goals = 0;
        score.text = goals.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Disk")
        {
            goals++;
            score.text = goals.ToString();
        }
    }
}