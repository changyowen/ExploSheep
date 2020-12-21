using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    #region Singleton
    public static WaveManager instance;

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

    //access
    public GameObject[] UI_accessible;
    public Sprite[] opening_sprites;
    public GameObject OpeningCountDown;
    public GameObject gameOverPanel;
    public HPScript hPScript;

    private float Timer = 60f;
    public bool startGame = false;
    public int waveCount = 0;

    public AudioSource countDown;
    public AudioSource start;

    private bool triggered = false;
    private float GazeTimer;

    // Start is called before the first frame update
    void Start()
    {
        hPScript = GameObject.Find("HP").GetComponent<HPScript>();
        countDown = GameObject.Find("321").GetComponent<AudioSource>();
        start = GameObject.Find("Start").GetComponent<AudioSource>();
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
                    Debug.Log("YESS");
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

        if(waveCount >= 3 || hPScript.HP <= 0)
        {
            startGame = false;
            EndGame();
        }

        //gaze
        if (triggered == true)
        {
            GazeTimer += Time.deltaTime;
            if (GazeTimer > 1f)
            {
                GazeTimer = 0;
                triggered = false;
                ReturntoMainMenu();
            }
        }
        else
        {
            GazeTimer = 0;
        }
    }

    IEnumerator StartGame()
    {
        SpriteRenderer openingSR = OpeningCountDown.GetComponent<SpriteRenderer>();
        OpeningCountDown.SetActive(false);
        yield return new WaitForSeconds(1f);
        OpeningCountDown.SetActive(true);
        openingSR.sprite = opening_sprites[2];
        countDown.Play();
        yield return new WaitForSeconds(1f);
        openingSR.sprite = opening_sprites[1];
        countDown.Play();
        yield return new WaitForSeconds(1f);
        openingSR.sprite = opening_sprites[0];
        countDown.Play();
        yield return new WaitForSeconds(1f);
        OpeningCountDown.SetActive(false);
        start.Play();
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
        Timer = 60f;
        for (int i = 0; i < UI_accessible.Length; i++)
        {
            UI_accessible[i].SetActive(true);
        }
        QuestionGenerator.instance.StartQuestionGen();
        SpawnSheepManager.instance.StartSpawning = true;
    }

    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene(0);
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
