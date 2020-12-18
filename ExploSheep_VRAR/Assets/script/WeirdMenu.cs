using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeirdMenu : MonoBehaviour
{
    private int Index = 0;
    private bool triggered = false;
    private float Timer;

    public GameObject Player;
    public GameObject weirdMenu_canvas;
    public GameObject Slime;

    List<GameObject> SlimeList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (triggered == true)
        {
            Timer += Time.deltaTime;
            if (Timer > 1f)
            {
                ShowMenu();
            }
        }
        else
        {
            Timer = 0;
        }
    }

    public void Triggered()
    {
        triggered = true;
    }

    public void Nontriggered()
    {
        triggered = false;
    }

    void ShowMenu()
    {
        weirdMenu_canvas.SetActive(true);
    }

    public void CreateSlime()
    {
        Vector3 PlayerPosition = new Vector3(Player.transform.position.x, 5f, Player.transform.position.z);
        Vector3 spawnPosition = new Vector3(Random.Range(-3f, 3f), 5, Random.Range(-3f, 3f));
        Vector3 spawningPlace = new Vector3(spawnPosition.x + Player.transform.position.x, 5f, spawnPosition.z + Player.transform.position.z);
        GameObject slime = Instantiate(Slime, spawningPlace, Quaternion.identity) as GameObject;
        slime.transform.LookAt(PlayerPosition);
        SlimeList.Add(slime);
    }

    public void RemoveSlime() //from first
    {
        if (SlimeList.Count == 0)
        {
            return;
        }
        else
        {
            GameObject removedSlime = SlimeList[0];
            SlimeList.RemoveAt(0);
            Destroy(removedSlime);
        }
    }

    public void RemoveSlime2() //from last
    {
        if (SlimeList.Count == 0)
        {
            return;
        }
        else
        {
            GameObject removedSlime = SlimeList[SlimeList.Count - 1];
            SlimeList.RemoveAt(SlimeList.Count - 1);
            Destroy(removedSlime);
        }
    }
}
