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
    // Start is called before the first frame update
    void Start()
    {
        
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

        if(Physics.Raycast(ray, out _hit, RayDistance))
        {
            if (imgGaze.fillAmount == 1)
            {
                imgGaze.fillAmount = 0;
                gvrStatus = false;
                if (_hit.transform.CompareTag("StartGame"))
                {
                    _hit.transform.gameObject.GetComponent<Text>().color = Color.gray;
                    string name = _hit.transform.gameObject.name;
                    _hit.transform.gameObject.GetComponent<MainMenuRedirect>().StartGame();
                }
                else if (_hit.transform.CompareTag("ExitGame"))
                {
                    _hit.transform.gameObject.GetComponent<MainMenuRedirect>().ExitGame();
                }
            }
        }
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;

    }
}
