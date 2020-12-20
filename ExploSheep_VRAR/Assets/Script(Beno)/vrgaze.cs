using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class vrgaze : MonoBehaviour
{
    public Image imgGaze;

    public float totalTime = 1;
    bool gvrStatus;
    float gvrTimer;
    bool loadOnce = false;

    public int RayDistance = 30;
    private RaycastHit _hit;

    public EventTrigger trigger;

    //public Image imageGaze;

    //public float totalTime = 2;
    //bool notGazing;
    //bool isGazing;

    public static bool isStartButton;
    public static bool isQuitButton;

    //public int distance = 10;

    //public GameObject loadingCircle;

    //public static bool isFinishLoading;

    // Start is called before the first frame update
    void Start()
    {
        //loadingCircle.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));

        if (Physics.Raycast(ray, out _hit, RayDistance))
        {
            if (imgGaze.fillAmount == 1)
            {
                imgGaze.fillAmount = 0;
                gvrStatus = false;
                if (_hit.transform.CompareTag("StartGame"))
                {
                    isStartButton = true;
                    isQuitButton = false;
                    //_hit.transform.gameObject.GetComponent<Text>().color = Color.gray;
                    //string name = _hit.transform.gameObject.name;
                    //_hit.transform.gameObject.GetComponent<MainMenuRedirect>().StartGame();
                }
                else if (_hit.transform.CompareTag("ExitGame"))
                {
                    Debug.Log("Quit Game");
                    isQuitButton = true;
                    isStartButton = false;
                    //_hit.transform.gameObject.GetComponent<MainMenuRedirect>().ExitGame();
                }
            }
        }
    }

        //    if (isGazing && loadingCircle.GetComponent<Image>().fillAmount < 1)
        //    {
        //        Debug.Log("Load Circle");
        //        StartLoad();
        //    }


        //    RaycastHit hits;
        //    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        //    if (Physics.Raycast(ray, out hits, distance))
        //    {
        //        if (isFinishLoading && hits.transform.CompareTag("StartGame"))
        //        {
        //            Debug.Log("Start Button");
        //            imageGaze.fillAmount = 1;
        //            isStartButton = true;
        //            isQuitButton = false;
        //        }

        //        else if (isFinishLoading && hits.transform.CompareTag("ExitGame"))
        //        {
        //            Debug.Log("Quit Button");
        //            imageGaze.fillAmount = 1;
        //            isQuitButton = true;
        //            isStartButton = false;
        //        }
        //    }
        //}

        public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
        isStartButton = false;
        isQuitButton = false;
    }

    //public void SetGazedAt(bool gazedAt)
    //{
    //    if (gazedAt)
    //    {
    //        isGazing = true;
    //        notGazing = false;
    //    }
    //    else
    //    {
    //        isGazing = false;
    //        notGazing = true;
    //        ResetLoad();
    //    }
    //}

    //public void StartLoad()
    //{
    //    if (loadingCircle.GetComponent<Image>().fillAmount < 1)
    //    {
    //        loadingCircle.GetComponent<Image>().fillAmount += Time.deltaTime;

    //        if (!notGazing && loadingCircle.GetComponent<Image>().fillAmount == 1)
    //        {
    //            loadingCircle.GetComponent<Image>().fillAmount = 1;
    //            isFinishLoading = true;
    //        }
    //    }
    //}

    //public void ResetLoad()
    //{
    //    loadingCircle.GetComponent<Image>().fillAmount = 0;
    //    isFinishLoading = false;
    //}
}
