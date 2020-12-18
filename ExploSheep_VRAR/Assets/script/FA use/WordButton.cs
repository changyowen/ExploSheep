using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordButton : MonoBehaviour
{
    public int index = 0;

    private bool triggered = false;
    private float Timer;

    AudioSource audiosrc;
    AudioClip buttonClip;

    void Start()
    {
        audiosrc = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        buttonClip = Resources.Load<AudioClip>("Button");
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered == true)
        {
            Timer += Time.deltaTime;
            if (Timer > 1.5f)
            {
                Timer = 0;
                triggered = false;
                audiosrc.PlayOneShot(buttonClip);
                GameManager.instance.Guess(index);
            }
        }
        else
        {
            Timer = 0;
        }
    }

    public void Triggered()
    {
        triggered = true;
    }

    public void Nontriggered()
    {
        triggered = false;
    }
}
