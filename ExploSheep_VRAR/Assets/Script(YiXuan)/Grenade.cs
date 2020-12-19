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
        if(other.tag == "InfectedSheep")
        {
            Sniper_Script.isInfectedSheep = false;
            Sniper_Script.isHealthySheep = true;
            Debug.Log("sheep cleansed");
        }
    }

    IEnumerator ExplodeTime()
    {
        yield return new WaitForSeconds(2f);
        grenadeCollider.enabled = true;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
