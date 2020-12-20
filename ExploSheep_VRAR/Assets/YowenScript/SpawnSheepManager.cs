using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSheepManager : MonoBehaviour
{
    #region Singleton
    public static SpawnSheepManager instance;

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

    public GameObject sheep_gameObj;

    //accessable data
    public Vector2 spawnableAngle;
    public Transform spawnCenter;
    public float radius;
    public float spawnCooldown = 3f;

    //system use
    public bool StartSpawning = false;
    bool invertSpawnArea = false;
    float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Timer = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(StartSpawning == true)
        {
            Timer += Time.deltaTime;
            if(Timer >= spawnCooldown)
            {
                SpawnSheep();
                invertSpawnArea = !invertSpawnArea;
                Timer = 0;
            }
        }
        else
        {
            Timer = 0;
        }
    }

    void SpawnSheep()
    {
        float randomSpawnAngle = ((Random.Range(spawnableAngle.x, spawnableAngle.y))) * 3.14f / 180;
        float spawnPointX = (radius * Mathf.Cos(randomSpawnAngle)) + spawnCenter.position.x;
        float spawnPointZ = (radius * Mathf.Sin(randomSpawnAngle)) + spawnCenter.position.z;
        if(invertSpawnArea == true)
        {
            spawnPointZ = ((spawnPointZ - spawnCenter.position.z) * -1) + spawnCenter.position.z;
        }
        Vector3 SheepSpawnPoint = new Vector3(spawnPointX, 6f, spawnPointZ);

        GameObject Sheep = Instantiate(sheep_gameObj, SheepSpawnPoint, Quaternion.identity) as GameObject;
        Sheep.name = "Sheep";
        SheepMovement sheepMovement = Sheep.GetComponent<SheepMovement>();
        sheepMovement.player_transform = spawnCenter;
    }
}
