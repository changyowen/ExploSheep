using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    //access
    public GameObject[] UI_accessible;
    public Sprite[] opening_sprites;
    public Image opening_UI;
    public GameObject gameOverPanel;

    private float Timer = 60f;
    private bool startGame = false;
    private int waveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        if(startGame == true)
        {
            Timer -= Time.deltaTime;
            if(Timer <= 0)
            {
                SpawnSheepManager.instance.StartSpawning = false;
                if (GameObject.Find("Sheep") == null)
                {
                    StartWave();
                    waveCount++;
                }
            }
        }
        else
        {
            for(int i = 0; i < UI_accessible.Length; i++)
            {
                UI_accessible[i].SetActive(false);
            }
        }

        if(waveCount >= 3)
        {
            startGame = false;
            EndGame();
        }
    }

    IEnumerator StartGame()
    {
        opening_UI.transform.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        opening_UI.transform.gameObject.SetActive(true);
        opening_UI.sprite = opening_sprites[2];
        yield return new WaitForSeconds(1f);
        opening_UI.sprite = opening_sprites[1];
        yield return new WaitForSeconds(1f);
        opening_UI.sprite = opening_sprites[0];
        yield return new WaitForSeconds(1f);
        opening_UI.transform.gameObject.SetActive(false);
        StartWave();
    }

    void EndGame()
    {
        SpawnSheepManager.instance.StartSpawning = false;
        Animator anim = gameOverPanel.GetComponent<Animator>();
        anim.SetBool("Showing", true);
    }

    void StartWave()
    {
        startGame = true;
        for (int i = 0; i < UI_accessible.Length; i++)
        {
            UI_accessible[i].SetActive(true);
        }
        QuestionGenerator.instance.StartQuestionGen();
        SpawnSheepManager.instance.StartSpawning = true;
    }
}
