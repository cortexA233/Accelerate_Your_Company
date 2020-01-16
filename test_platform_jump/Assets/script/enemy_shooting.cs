using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shooting : MonoBehaviour
{
    public float bul_spd_x, bul_spd_y,bul_lifetime;
    public GameObject bullet;
    GameObject bul;
    public int dir;//-1向左，1向右
    float shoot_count, shoot_speed;
    // Start is called before the first frame update
    void Start()
    {
        bul_lifetime = 2f;
        shoot_count = 0f;
        shoot_speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        shoot_count += Time.deltaTime;
        if (shoot_count >= shoot_speed)
        {
            shoot_count = 0f;
            Transform newpos = transform;
            Quaternion newrot = new Quaternion(0, 0, 0, 0);
            //  newpos.position = new Vector2(newpos.position.x + 0.5f * dir, newpos.position.y);
            bul = Instantiate(bullet, new Vector2(newpos.position.x + 1f * (dir), newpos.position.y - 0.2f), newrot);
            bul.GetComponent<bul_move>().dir = dir;
            bul.GetComponent<bul_move>().spdx = bul_spd_x;
            bul.GetComponent<bul_move>().spdy = bul_spd_y;
            bul.transform.Translate(new Vector2(0, 0.4f));
            Invoke("destroy_bul", 2f);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "bullet" ) 
        {
            Destroy(this.gameObject);
        }
    }
    void destroy_bul()
    {
        Destroy(bul);
    }

}
