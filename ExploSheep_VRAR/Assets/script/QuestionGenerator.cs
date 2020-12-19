using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour
{
    #region Singleton
    public static QuestionGenerator instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameManager found!");
            return;
        }
        instance = this;
    }
    #endregion

    int randomNum1, randomNum2;
    int randomSymbol;
    public int result;
    public int answerCount;
    public int[] answers = new int[50];

    public Text questionText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuestionGen ()
    {
        System.Random rand = new System.Random();

        randomNum1 = rand.Next(0, 100);
        randomSymbol = rand.Next(0, 2);
        int tempnum;
        if (randomSymbol == 0)
        {
            tempnum = 99 - randomNum1;

            randomNum2 = rand.Next(1, tempnum);
            result = randomNum1 + randomNum2;
            questionText.text = randomNum1 + " + " + randomNum2 + " = ???";
        }
        else if (randomSymbol == 1)
        {
            tempnum = randomNum1;
            randomNum2 = rand.Next(1, tempnum);
            result = randomNum1 - randomNum2;
            questionText.text = randomNum1 + " - " + randomNum2 + " = ???";
        }


    }
}
