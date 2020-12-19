using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_Script : MonoBehaviour
{
    public float damage = 10f;

    public float range = 100f;

    public Camera fpsCam;

    float sniperTimer = 0;

    Sheep sheep;

    public HPScript script;

    RaycastHit hits;
    public int maxChance;
    public static int spawnNadeChance;
    public static bool isInfectedSheep;
    public static bool isHealthySheep;

    public AudioSource sniperFire;

    public ParticleSystem sniperMuzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        isInfectedSheep = false;
        isHealthySheep = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hits, range))
        {
            //Debug.Log(hits.transform.name);

            sheep = hits.transform.GetComponent<Sheep>();

            //if (sheep != null)
            //{
            //    Debug.Log("Starting Coroutine");
            //    StartCoroutine(TwoSecondsCoroutine());               
            //}

            if (hits.collider.tag == "InfectedSheep")
            {
                sniperTimer += Time.deltaTime;
                if (sniperTimer >= 2)
                {
                    TwoSecondsCoroutine();
                    sniperTimer = 0;
                }
                Debug.Log("isInfectedSheep");
                isInfectedSheep = true;
                isHealthySheep = false;      
            }
            else
            if (hits.collider.tag == "Sheep")
            {
                sniperTimer += Time.deltaTime;
                if (sniperTimer >= 2)
                {
                    TwoSecondsCoroutine();
                    sniperTimer = 0;
                }
                //Debug.Log("isSheep");
                isHealthySheep = true;
                isInfectedSheep = false;               
            }
            else
            {
                //Debug.Log("not Sheep");
                isInfectedSheep = false;
                isHealthySheep = false;
            }
        }
        else
        {
            //Debug.Log("not Sheep");
            isInfectedSheep = false;
            isHealthySheep = false;
        }

    }

    public void TwoSecondsCoroutine()
    {
        if (isInfectedSheep && !isHealthySheep /*&& CameraRaycast.loader.fillAmount == 1*/)
        {
            Debug.Log("Infected Sheep :(");
            sniperFire.Play();
            sniperMuzzleFlash.Play();
            spawnNadeChance = Random.Range(0, maxChance);
            sheep.TakeDamge(damage);
        }
        
        if (isHealthySheep && !isInfectedSheep /*&& CameraRaycast.loader.fillAmount == 1*/)
        {
            Debug.Log("bla");
            script.DeductHP();
            Debug.Log("Healthy Sheep :)");
            sniperFire.Play();
            sniperMuzzleFlash.Play();
            sheep.TakeDamge(damage);
        }
    }
}
