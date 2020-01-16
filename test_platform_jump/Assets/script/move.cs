using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource roar;
    public GameObject stand, walking, attack_down, attack_up;
    int dir = 0;//0向左，1向右
    Rigidbody2D rig;
    GameObject buddy;
    void Start()
    {
        roar = GetComponent<AudioSource>();
        buddy = GameObject.FindGameObjectWithTag("buddy");
        rig = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void anime_stop()
    {
        gameObject.GetComponent<Animator>().StopPlayback();
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = stand.GetComponent<SpriteRenderer>().sprite;
    }
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(glob.player_direcion, transform.localScale.y);
        if (Input.GetKeyDown(KeyCode.I))
        {
            glob.respawn();
            glob.cur_life -= 10f;
        }
        if (!Input.anyKey && glob.weapon_status == 0) 
        {
            anime_stop();
        }
        float cx = rig.position.x, cy = rig.position.y ;
        if (Input.GetKeyDown(KeyCode.Space) && glob.is_ground == 1) 
        {
            rig.AddForce(new Vector2(0, 88888f));
            glob.is_ground = 0;
            if (glob.is_stranding_player == 1)
            {
                glob.is_stranding_player = 0;
                rig.gravityScale = 1f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (glob.is_stranding_player == 1)
            {
                transform.Translate(new Vector2(1f, 0));
            }
            glob.is_stranding_player = 0;
            rig.gravityScale = 1f;
        }

        if (Input.GetKey(KeyCode.W) && glob.is_stranding_player == 1)  
        {
            transform.Translate(new Vector2(0, 3f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S) && glob.is_stranding_player == 1)
        {
            transform.Translate(new Vector2(0, -3f * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D) && glob.is_stranding_player == 0)
        {
            if (glob.weapon_status == 0)
            {
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<Animator>().runtimeAnimatorController = walking.GetComponent<Animator>().runtimeAnimatorController;
            }

            glob.player_direcion = 1;
            if (dir == 1)
            {
               

               
            //    weapon.transform.Translate(new Vector2(0.7f, 0), Space.World);
            }
            dir = 0;
            if (glob.is_ground == 1)
            {
                transform.Translate(new Vector2(4.5f * Time.deltaTime, 0), Space.World);
                //rig.MovePosition(new Vector2(transform.position.x + 40f * Time.deltaTime, transform.position.y));
            }
            else
            {
                transform.Translate(new Vector2(4.5f * Time.deltaTime, 0),Space.World);
            }
            
        }
        if (Input.GetKey(KeyCode.A) && glob.is_stranding_player == 0)
        {
            if (glob.weapon_status == 0)
            {
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<Animator>().runtimeAnimatorController = walking.GetComponent<Animator>().runtimeAnimatorController;
            }
                

            glob.player_direcion = -1;
            if (dir == 0)
            {
        //        weapon.transform.Translate(new Vector2(-0.7f, 0),Space.World);
            }
            dir = 1;
            if (glob.is_ground == 1)
            {
                transform.Translate(new Vector2(-4.5f * Time.deltaTime, 0), Space.World);
                //rig.MovePosition(new Vector2(transform.position.x - 40f * Time.deltaTime, transform.position.y));
            }
            else
            {
                transform.Translate(new Vector2(-4.5f * Time.deltaTime, 0), Space.World);
            }
            
        }


        if (Input.GetKeyDown(KeyCode.J) && glob.weapon_status == 0)
        {
            if (roar.isPlaying == true)
            {
                roar.Stop();
            }
            roar.Play();
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = attack_down.GetComponent<Animator>().runtimeAnimatorController;
            glob.weapon_status = 1;
          //  weapon.transform.localEulerAngles = new Vector3(0, 0, dir * 90f + 45f);
            Invoke("attack_recover", 0.8f);
        }
        if (Input.GetKeyDown(KeyCode.K) && glob.weapon_status == 0)
        {
            if (roar.isPlaying == true)
            {
                roar.Stop();
            }
            roar.Play();
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = attack_up.GetComponent<Animator>().runtimeAnimatorController;
            glob.weapon_status = 2;
         //   weapon.transform.localEulerAngles = new Vector3(0, 0, dir * 210f + (-15f));
            Invoke("attack_recover", 0.75f);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            attack_recover();
        }

    }
    void attack_recover()
    {
        glob.weapon_status = 0;
   //     weapon.transform.localEulerAngles = new Vector3(0, 0, 90f);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        /*
        if (col.collider.tag == "buddy" && transform.position.y >= buddy.transform.position.y + 0.5f)
        {

            transform.parent = buddy.transform;
            transform.localScale = new Vector2(1/6f, 1/6f);
        }
        */
        if (col.collider.tag == "wall" || col.collider.tag == "buddy") 
        {
            glob.is_ground = 1;
        }
        if (col.collider.tag == "key")
        {
            Destroy(col.collider.gameObject);
            glob.is_key = 1;
        }
        if (col.collider.tag == "lock" && glob.is_key == 1) 
        {
            Destroy(col.collider.gameObject);
        }
        if (col.collider.tag == "hell")
        {
            glob.respawn();
        }
    }
}

