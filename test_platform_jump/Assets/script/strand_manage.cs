using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strand_manage : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rig;
    int force_dir;//
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        rig = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "player" || col.collider.tag == "weapon") 
        {
            if (player.transform.position.x > transform.position.x)
            {
                force_dir = -1;
            }
            else
            {
                force_dir = 1;
            }
            rig.AddForce(new Vector2(force_dir * 99999f, 0));
            Debug.Log("strand");
            glob.is_stranding_player = 1;
            rig.gravityScale = 0;
        }
    }
}
