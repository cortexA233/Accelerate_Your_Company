using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sound : MonoBehaviour
{
    float t;
    public Scene sss;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 2.2f)
        {
            t = 0;
            if (GetComponent<AudioSource>().isPlaying == true)
            {
                GetComponent<AudioSource>().Stop();
            }
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
