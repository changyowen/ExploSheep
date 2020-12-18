using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRaycast : MonoBehaviour
{
    Camera cam;
    public Image loadingCircle;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag == "Teleport" || hit.transform.tag == "WeirdMenu")
            {
                loadingCircle.fillAmount += Time.deltaTime / 1f;
                if(loadingCircle.fillAmount >= 1)
                {
                    loadingCircle.fillAmount = 0;
                }
            }
        }
        else
        {
            loadingCircle.fillAmount = 0;
        }
    }
}
