using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSheepManager : MonoBehaviour
{
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
    }

    void SpawnSheep()
    {
        float randomSpawnAngle = ((Random.Range(spawnableAngle.x, spawnableAngle.y))-90) * 3.14f / 180;
        float spawnPointX = (radius * Mathf.Cos(randomSpawnAngle)) + spawnCenter.position.x;
        float spawnPointZ = (radius * Mathf.Sin(randomSpawnAngle)) + spawnCenter.position.z;
        if(invertSpawnArea == true)
        {
            spawnPointZ = ((spawnPointZ - spawnCenter.position.z) * -1) + spawnCenter.position.z;
        }
        Vector3 SheepSpawnPoint = new Vector3(spawnPointX, 6f, spawnPointZ);

        GameObject Sheep = Instantiate(sheep_gameObj, SheepSpawnPoint, Quaternion.identity) as GameObject;
        SheepMovement sheepMovement = Sheep.GetComponent<SheepMovement>();
        sheepMovement.player_transform = spawnCenter;
    }
}
