using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGrenade : MonoBehaviour
{
    
    public Transform enemyPosition;
    public Transform grenade;

    public void SpawnNade()
    {
       Instantiate(grenade,new Vector3(enemyPosition.position.x,enemyPosition.position.y,enemyPosition.position.z),Quaternion.identity);
    }
}
