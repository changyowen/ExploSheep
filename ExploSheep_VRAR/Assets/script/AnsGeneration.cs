using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AnsGeneration : MonoBehaviour
{
    int answer;
    int finalAns;
    public TextMesh ansText;
    
    // Start is called before the first frame update
    void Start()
    {
        answer = QuestionGenerator.instance.result;
        System.Random rand = new System.Random();
        finalAns = answer + rand.Next(-1,2);
        ansText.text = finalAns.ToString();
    }

    public bool IsThisCorrect()
    {
        if(finalAns == answer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeAnswer()
    {
        finalAns = answer;
        ansText.text = finalAns.ToString();
    }
}
