using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuRedirect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vrgaze.isStartButton)
        {
            vrgaze.isStartButton = false;
            SceneManager.LoadScene("Narration");
        }

        if (vrgaze.isQuitButton)
        {
            vrgaze.isQuitButton = false;
            Application.Quit();
        }
    }
}
