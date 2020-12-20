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

        int randomCorrect = UnityEngine.Random.Range(0, 2);

        if(randomCorrect == 0)
        {
            finalAns = answer + UnityEngine.Random.Range(-4, 5);
        }
        else
        {
            finalAns = answer;
        }
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
