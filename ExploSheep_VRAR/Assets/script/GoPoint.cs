using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPoint : MonoBehaviour
{
    public GameObject Player;
    private float Timer;
    private bool triggered = false;

    // Update is called once per frame
    void Update()
    {
        if(triggered == true)
        {
            Timer += Time.deltaTime;
            if(Timer > 1f)
            {
                Vector3 position;
                position = new Vector3(this.gameObject.transform.position.x, Player.transform.position.y, this.gameObject.transform.position.z);
                Player.transform.position = position;
                Timer = 0;
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

    public void NonTriggered()
    {
        triggered = false;
    }
}
