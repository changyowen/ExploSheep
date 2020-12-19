using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AnsGeneration : MonoBehaviour
{
    public QuestionGenerator Questions;
    int answer;
    int finalAns;
    Text ansText;
    
    // Start is called before the first frame update
    void Start()
    {
        ansText = this.gameObject.GetComponentInChildren<Text>();
        answer = Questions.result;
        System.Random rand = new System.Random();
        finalAns = answer + rand.Next(-5, 6);
        ansText.text = finalAns.ToString();
    }


}
