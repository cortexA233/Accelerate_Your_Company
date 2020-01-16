using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_con : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("player");
        transform.parent = player.transform;
    }
}
