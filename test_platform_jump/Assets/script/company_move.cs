using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class company_move : MonoBehaviour
{
    public GameObject running,walking,shrinking;
    GameObject player;
    float boxsize;
    Rigidbody2D rig;
    int is_s = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (glob.isiii == 0)
        {
            glob.isiii = 1;
       //     SceneManager.LoadScene("begin");
        }
        
        gameObject.GetComponent<Animator>().runtimeAnimatorController = walking.GetComponent<Animator>().runtimeAnimatorController;
        player = GameObject.FindGameObjectWithTag("player");
        rig = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(-glob.buddy_direcion*6f, transform.localScale.y);
        player = GameObject.FindGameObjectWithTag("player");
        float cx = transform.position.x, cy = transform.position.y, player_x = player.transform.position.x, player_y = player.transform.position.y;
        if (dist(cx, cy, player_x, player_y) >= 12f)
        {
            is_s = 1;
            glob.cur_life -= 0.1f;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = shrinking.GetComponent<Animator>().runtimeAnimatorController;
            gameObject.GetComponent<Animator>().enabled = true;
        }
        else
        {
            if (is_s == 1)
            {
                is_s = 0;
                gameObject.GetComponent<Animator>().runtimeAnimatorController = walking.GetComponent<Animator>().runtimeAnimatorController;
                gameObject.GetComponent<Animator>().enabled = true;
            }
            
            if (glob.cur_life < glob.max_life)
            {
                glob.cur_life += 0.1f;
            }
            transform.Translate(new Vector2(glob.buddy_dir * 1.8f * Time.deltaTime, 0));
        }
        if (glob.is_ground == 1 && player.transform.position.x < transform.position.x)
        {
            glob.buddy_direcion = 1;
            glob.buddy_dir = 1;
        }
        if (glob.is_ground == 1 && player.transform.position.x > transform.position.x)
        {
            glob.buddy_direcion = -1;
            glob.buddy_dir = -1;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (glob.weapon_status == 1 && col.collider.tag == "player") 
        {
            Debug.Log("!!!!!!!");
            gameObject.GetComponent<Animator>().runtimeAnimatorController = running.GetComponent<Animator>().runtimeAnimatorController;
            gameObject.GetComponent<Animator>().enabled = true;
            glob.is_rush = 1;
            Invoke("recover_rush", 3f);
            rig.AddForce(new Vector2(glob.buddy_dir * 711111f, 0));
        }
        if (glob.weapon_status == 2 && col.collider.tag == "player")
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = running.GetComponent<Animator>().runtimeAnimatorController;
            gameObject.GetComponent<Animator>().enabled = true;
            glob.is_rush = 1;
         //   glob.buddy_is_ground = 0;
            rig.AddForce(new Vector2(0, 1111111f));
            if (Input.GetKey(KeyCode.A))
            {
                rig.AddForce(new Vector2(-111111f, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                rig.AddForce(new Vector2(111111f, 0));
            }
            Invoke("recover_rush", 3f);
        }
        if (col.collider.tag == "wall")
        {
            glob.buddy_is_ground = 1;
            recover_rush();
        }
        if (col.collider.tag == "thorn")
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = running.GetComponent<Animator>().runtimeAnimatorController;
            gameObject.GetComponent<Animator>().enabled = true;
            rig.AddForce(new Vector2(111111f, 777666f*1.1f));
            Invoke("recover_rush", 3f);
        }
        if (col.collider.tag == "hell")
        {
            glob.respawn();
        }
        if (col.collider.tag == "water")
        {
            boxsize = 2f;
        }
    }
    void recover_rush()
    {
        gameObject.GetComponent<Animator>().runtimeAnimatorController = walking.GetComponent<Animator>().runtimeAnimatorController;
        gameObject.GetComponent<Animator>().enabled = true;
        glob.is_rush = 0;
    }
    float dist(float x1, float y1, float x2, float y2)
    {
        float dis = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
        return Mathf.Sqrt(dis);
    }
}
