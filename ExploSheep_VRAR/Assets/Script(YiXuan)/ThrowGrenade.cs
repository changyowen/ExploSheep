using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    
    public Transform enemyPosition;
    public Transform grenade;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SpawnNade();
        }
    }
    public void SpawnNade()
    {
       Instantiate(grenade,new Vector3(enemyPosition.position.x,enemyPosition.position.y,enemyPosition.position.z),Quaternion.identity);
    }
}
