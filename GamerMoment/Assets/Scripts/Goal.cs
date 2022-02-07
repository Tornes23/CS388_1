using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text score;
    public int player_index;
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
        if(goals == 10)
        {
            //win screen

        }
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
