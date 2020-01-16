using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shining : MonoBehaviour
{
    public Sprite s1, s2;
    float t;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 1f)
        {
            t = 0;
            if (i == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = s1;
                i = 2;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = s2;
                i = 1;
            }
        }
    }
}
