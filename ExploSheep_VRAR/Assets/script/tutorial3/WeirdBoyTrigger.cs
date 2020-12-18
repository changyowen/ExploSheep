using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeirdBoyTrigger : MonoBehaviour
{
    //access
    DialogTrigger dialogTrigger;
    DialogManager dialogManager;

    private bool triggered = false;
    private float Timer;

    private bool startConversation = false;
    private int dialogIndex = 0;

    void Start()
    {
        dialogTrigger = GetComponent<DialogTrigger>();
        dialogManager = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered == true)
        {
            Timer += Time.deltaTime;
            if (Timer > 1f)
            {
                if(startConversation == false)
                {
                    startConversation = true;

                    switch(dialogIndex)
                    {
                        case 0:
                            {
                                dialogTrigger.TriggerDialog();
                                break;
                            }
                    }
                    Timer = 0;
                }
                else
                {
                    switch (dialogIndex)
                    {
                        case 0:
                            {
                                dialogManager.DisplayNextSentence();
                                break;
                            }
                    }
                    Timer = 0;
                }
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
