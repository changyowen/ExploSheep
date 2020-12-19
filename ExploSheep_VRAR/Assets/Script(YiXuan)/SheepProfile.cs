using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepProfile : MonoBehaviour
{
    public static bool sheepStat;
    public bool goodSheep;
    // Start is called before the first frame update
    void Start()
    {
        sheepStat = false;
    }

    // Update is called once per frame
    void Update()
    {
        goodSheep = sheepStat;
    }
}
