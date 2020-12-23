using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeWritter : MonoBehaviour
{
    public float timer;
    public string fullText1, fullText2, fullText3, fullText4;
    public string currentText = "";
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        
        for (int i = 0; i < fullText1.Length; i++)
        {
            currentText = fullText1.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(timer);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < fullText2.Length; i++)
        {
            currentText = fullText2.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(timer);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < fullText3.Length; i++)
        {
            currentText = fullText3.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(timer);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < fullText4.Length; i++)
        {
            currentText = fullText4.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(timer);
        }

        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("MainGame");
    }

}
