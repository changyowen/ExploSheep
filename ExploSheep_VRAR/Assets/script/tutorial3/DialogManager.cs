using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text nameText;
    public Text dialogText;

    public GameObject weirdBoy;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialog dialog)
    {
        nameText.text = dialog.name; 

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        string sentence = sentences.Dequeue();
        dialogText.text = sentence;

        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
    }

    void EndDialog()
    {
        StartCoroutine(StartQuestion());
    }

    IEnumerator StartQuestion()
    {
        weirdBoy.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(5f);

        dialogBox.SetActive(false);
        //question box set active true
    }
}
