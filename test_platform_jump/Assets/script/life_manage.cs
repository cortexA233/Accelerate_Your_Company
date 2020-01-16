using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_manage : MonoBehaviour
{
    GameObject life_gauge, player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        life_gauge = GameObject.FindGameObjectWithTag("life_gauge");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("player");
        if (glob.cur_life <= 0f)
        {
            glob.respawn();
        }
        Vector3 v3 = player.transform.position;
        v3.x += 5f;
        v3.y += 4f;
        transform.position = v3;
        life_gauge.transform.localScale = new Vector2(glob.cur_life * 0.1f, 1f);
    }
}
