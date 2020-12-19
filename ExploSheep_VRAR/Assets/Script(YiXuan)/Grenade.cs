using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Collider grenadeCollider;
    public ParticleSystem particle;

    public AudioSource boom;
    void Start()
    {
        boom = GameObject.Find("Grenade").GetComponent<AudioSource>();

        StartCoroutine(ExplodeTime());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "InfectedSheep")
        {
            other.transform.GetChild(2).transform.GetChild(0).GetComponent<AnsGeneration>().ChangeAnswer();
            Sniper_Script.isInfectedSheep = false;
            Sniper_Script.isHealthySheep = true;
            Debug.Log("sheep cleansed");
        }
    }

    IEnumerator ExplodeTime()
    {
        yield return new WaitForSeconds(2f);
        grenadeCollider.enabled = true;
        particle.Play();
        boom.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
