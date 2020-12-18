using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of GameManager found!");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject wheelUI;
    public GameObject spinButton;
    public GameObject[] wordUI;
    public GameObject[] wordButtons;
    public GameObject[] answerSlots;
    public Text playerScore_text;
    public Text playerRound_text;
    public AudioSource audiosrc;
    public AudioClip correctClip, wrongClip, winClip;
    public GameObject Firework;

    int[] AnswerArray = { 22, 9, 18, 20, 21, 1, 12, 18, 5, 1, 12, 9, 20, 25 };

    //system data
    int playerScore = 0;
    int playerRound = 1;
    public int scoreThisRound = 0;

    void Start()
    {
        StartFortuneWheel();
    }

    void Update()
    {
        playerScore_text.text = "Score:\t" + playerScore;
        playerRound_text.text = "Round:\t" + playerRound;
    }

    public void StartFortuneWheel()
    {
        for(int i = 0; i < wordUI.Length; i++)
        {
            wordUI[i].SetActive(false);
        }
        wheelUI.SetActive(true);
        spinButton.SetActive(true);
        wheelUI.transform.GetChild(0).GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
    }

    public void StartGuessing(int score)
    {
        wheelUI.SetActive(false);
        scoreThisRound = score;
        for (int i = 0; i < wordUI.Length; i++)
        {
            wordUI[i].SetActive(true);
        }
        wordUI[3].GetComponent<Text>().text = "Chance:\t$" + score;

        //for (int i = 0; i < wordButtons.Length; i++)
        //{
        //    if(wordButtons[i] != null)
        //    {
        //        wordButtons[i].SetActive(true);
        //    }
        //}

        wordUI[4].SetActive(false);
        wordUI[5].SetActive(false);
    }

    public void Guess(int index)
    {
        wordUI[4].SetActive(true);
        wordUI[5].SetActive(true);
        wordButtons[index].SetActive(false);

        bool correctGuess = false;
        for (int i = 0; i < AnswerArray.Length; i++)
        {
           if(AnswerArray[i] == index)
            {
                answerSlots[i].transform.GetChild(0).gameObject.SetActive(true);
                correctGuess = true;
                AnswerArray[i] = 0;
            }
        }

        int totalCorrect = 0;
        for(int i = 0; i < AnswerArray.Length; i++)
        {
            if(AnswerArray[i] == 0)
            {
                totalCorrect++;
            }
        }

        if(totalCorrect == AnswerArray.Length)
        {
            WinGame();
        }
        else
        {
            StartCoroutine(GoingForNextRound(correctGuess));
        }
    }

    IEnumerator GoingForNextRound(bool correctGuess)
    {
        if(correctGuess == true)
        {
            audiosrc.PlayOneShot(correctClip);
            playerScore += scoreThisRound;

        }
        else
        {
            audiosrc.PlayOneShot(wrongClip);
        }

        yield return new WaitForSeconds(3f);
        playerRound++;
        StartFortuneWheel();
    }

    void WinGame()
    {
        SoundManager.playWinMusic();
        Firework.SetActive(true);
        //show result panel
    }
}
