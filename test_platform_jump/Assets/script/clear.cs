using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (glob.iswin_player == 1 && glob.iswin_buddy == 1)
        {
            SceneManager.LoadScene("clear_scene");
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "buddy")
        {
            glob.iswin_buddy = 1;
            col.collider.transform.position = (new Vector2(170f, transform.position.y + 1f));
            col.collider.GetComponent<company_move>().enabled = false;
        }
        if (col.collider.tag == "player" || col.collider.tag == "weapon") 
        {
            glob.iswin_player = 1;
        }
    }
}
