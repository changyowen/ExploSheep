using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinButton : MonoBehaviour
{
    private bool triggered = false;
    private float Timer;

    public AudioSource audiosrc;
    public AudioClip buttonClip;

    // Update is called once per frame
    void Update()
    {
        if (triggered == true)
        {
            Timer += Time.deltaTime;
            if (Timer > 1f)
            {
                Timer = 0;
                triggered = false;
                audiosrc.PlayOneShot(buttonClip);
                Wheel.instance.TriggerSpin();
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
