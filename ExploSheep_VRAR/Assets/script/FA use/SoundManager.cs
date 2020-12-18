using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip WinClip;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        WinClip = Resources.Load<AudioClip>("WinClip");
    }

    //AttackBG
    public static void playWinMusic()
    {
        audioSrc.clip = WinClip;
        audioSrc.Play();
    }
}
