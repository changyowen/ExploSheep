using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
  
    public Collider grenadeCollider;
    void Start()
    {
        StartCoroutine(ExplodeTime());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "sheep")
        {
            SheepProfile.sheepStat = true;
            Debug.Log("sheep cleansed");
        }
    }

    IEnumerator ExplodeTime()
    {
        yield return new WaitForSeconds(2f);
        grenadeCollider.enabled = true;
    }
}
