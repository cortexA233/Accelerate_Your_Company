using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "player")
        {
            glob.respawn_posx = transform.position.x;
            glob.respawn_posy = transform.position.y;
        }
    }
}
