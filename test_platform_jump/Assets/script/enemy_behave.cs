using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behave : MonoBehaviour
{
    public float sx, ex;
    float mindis;
    // Start is called before the first frame update
    void Start()
    {
        mindis = 0;
        transform.position = new Vector2(sx, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float cx = transform.position.x, cy = transform.position.y;
        if ((cx <= sx || cx >= ex) && mindis >= 2f) 
        {
            mindis = 0;
            transform.Rotate(new Vector3(0, 0, 180f));
            transform.Translate(new Vector2(1.5f * Time.deltaTime, 0));
        }
        mindis += 3f * Time.deltaTime;
        transform.Translate(new Vector2(1.5f * Time.deltaTime, 0));
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "player" || col.collider.tag == "buddy")
        {
            if (glob.is_rush == 0)
            {
                glob.respawn();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
