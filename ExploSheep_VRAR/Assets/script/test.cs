﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using System;

public class test : MonoBehaviour
{
    private WebCamTexture camTexture;
    private Rect screenRect;
    void Start()
    {
        screenRect = new Rect(Screen.width / 4, Screen.height / 4, Screen.width/2, Screen.height/2);
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width;
        if (camTexture != null)
        {
            camTexture.Play();
        }
    } 

    void OnGUI()
    {
        // drawing the camera on screen
        GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
        // do the reading — you might want to attempt to read less often than you draw on the screen for performance sake
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(camTexture.GetPixels32(),
              camTexture.width, camTexture.height);
            if (result != null)
            {
                Debug.Log( result.Text ); 
            }
        }
        catch (Exception ex) { Debug.LogWarning(ex.Message); }  
    }
}
