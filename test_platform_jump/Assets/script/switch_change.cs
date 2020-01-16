using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_change : MonoBehaviour
{
    GameObject tricks;
    // Start is called before the first frame update
    void Start()
    {
        tricks = GameObject.FindGameObjectWithTag("trick");
    }

    // Update is called once per frame
    void Update()
    {
        if (glob.is_switch == 1)
        {
            Destroy(tricks);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "player") 
        {
            Debug.Log("!!!!!!");
            glob.is_switch = 1;
            Destroy(this.gameObject);
            
        }
    }
}
