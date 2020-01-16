using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bul_move : MonoBehaviour
{
    public int dir, is_back = 0;
    public float spdx, spdy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(spdx * Time.deltaTime, spdy * Time.deltaTime), Space.World);
        transform.Rotate(new Vector3(0, 0, 10f));
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        if (col.collider.tag == "buddy")
        {
            glob.respawn();
        }
        if (col.collider.tag == "player")
        {
            if (glob.weapon_status != 0)
            {
                spdx = -3f*spdx;
                spdy = -3f*spdy;
                dir = -dir;
                is_back = 1;
            }
            else
            {
                glob.respawn();
            }
        }
    }
}
