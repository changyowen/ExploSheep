using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    private bool triggered = false;
    private float Timer;

    public GameObject WeirdMenu_gameObject;
    WeirdMenu weirdMenu;

    void Start()
    {
        weirdMenu = WeirdMenu_gameObject.GetComponent<WeirdMenu>();
    }

    void Update()
    {
        if (triggered == true)
        {
            Timer += Time.deltaTime;
            if (Timer > .5f)
            {
                weirdMenu.RemoveSlime();
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

    public void Nontriggered()
    {
        triggered = false;
    }
}
