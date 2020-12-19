using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour
{
    public int HP = 3;
    public int currenHp;
    public GameObject[] HPImage = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            HPImage[i].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currenHp = HP + 1;
        if(HP == 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void DeductHP()
    {
        HP --;       
        HPImage[currenHp].SetActive(false);
    }
}
