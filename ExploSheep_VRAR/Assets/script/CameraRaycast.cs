using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRaycast : MonoBehaviour
{
    Camera cam;
    public Image loadingCircle;

    public static Image loader;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        loader = loadingCircle;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag == "Teleport" || hit.transform.tag == "WeirdMenu" || hit.transform.tag == "InfectedSheep" || hit.transform.tag == "Sheep")
            {
                loadingCircle.fillAmount += Time.deltaTime / 2f;
            }
            else
                loadingCircle.fillAmount = 0;
        }
        else
        {
            loadingCircle.fillAmount = 0;
        }
    }
}
