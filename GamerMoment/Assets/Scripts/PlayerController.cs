using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player1;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void GoTo(Vector3 target)
    {
        float step = speed * Time.deltaTime;
        player1.Translate(Vector3.Normalize(target - player1.position) * step);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
