using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable_wall : MonoBehaviour
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
        if (col.collider.tag == "buddy")
        {
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            this.gameObject.GetComponent<Animator>().enabled = true;
            Invoke("des", 1f);
        }
    }
    void des()
    {
        Destroy(this.gameObject);
    }
}
