using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    #region Singleton
    public static Wheel instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of WheelManager found!");
            return;
        }
        instance = this;
    }
    #endregion

    private int randomValue;
    private float timeInterval;
    private int finalAngle;

    public RectTransform wheelImage;
    public GameObject spinButton;
    public AudioSource audiosrc;
    public AudioClip WheelClip;

    //system data
    int scoreThisRound = 0;

    public void TriggerSpin()
    {
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        spinButton.SetActive(false);

        randomValue = Random.Range(50, 60);
        timeInterval = 0.1f;

        for (int i = 0; i < randomValue; i++)
        {
            wheelImage.Rotate(0, 0, 18f);
            audiosrc.PlayOneShot(WheelClip);

            if (i > Mathf.RoundToInt(randomValue * 0.5f))
            {
                timeInterval = 0.2f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.85f))
            {
                timeInterval = 0.4f;
            }

            yield return new WaitForSeconds(timeInterval);
        }

        if (Mathf.RoundToInt(wheelImage.eulerAngles.z) % 36 != 0)
        {
            wheelImage.Rotate(0, 0, 18f);
            audiosrc.PlayOneShot(WheelClip);
        }
            
        finalAngle = Mathf.RoundToInt(wheelImage.eulerAngles.z);

        switch (finalAngle)
        {
            case 0:
                scoreThisRound = 600;
                break;
            case 36:
                scoreThisRound = 700;
                break;
            case 72:
                scoreThisRound = 800;
                break;
            case 108:
                scoreThisRound = 900;
                break;
            case 144:
                scoreThisRound = 1000;
                break;
            case 180:
                scoreThisRound = 100;
                break;
            case 216:
                scoreThisRound = 200;
                break;
            case 252:
                scoreThisRound = 300;
                break;
            case 288:
                scoreThisRound = 400;
                break;
            case 324:
                scoreThisRound = 500;
                break;
        }

        yield return new WaitForSeconds(1.5f);

        GameManager.instance.StartGuessing(scoreThisRound);
    }
}
