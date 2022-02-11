using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Goal : MonoBehaviour
{
    public Text score;
    public GoalParticles emitter;
    public ReplayRestart menu;
    int goals;
    // Start is called before the first frame update
    void Start()
    {
        goals = 0;
        score.text = goals.ToString();
        emitter.GoalVFX();
    }

    // Update is called once per frame
    void Update()
    {
        //win condition
        if(goals == 7)
        {
            menu.ShowUI(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Disk")
        {
            goals++;
            score.text = goals.ToString();
            emitter.GoalVFX();
        }
    }
  
    public void Restart() { goals = 0; score.text = goals.ToString(); }
}
