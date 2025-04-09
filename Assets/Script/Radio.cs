using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEditor;

public class Radio : MonoBehaviour
{
    AudioSource audio;
    
    private string _path;
    public AudioClip[] songs;
    private int index;

    private float checkTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
        _path  = "Radio";

        /*if (SystemInfo.operatingSystem.Contains("Mac"))
        {
            _path = Application.dataPath + "/Resources/Data/StreamingAssets/Radio";
        }*/

        songs = Resources.LoadAll<AudioClip>(_path);
        
        //print(_path);
        //print(Resources.LoadAll(_path).Length);
        
        audio.clip = songs[index];
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        checkTimer += Time.deltaTime;
        if (checkTimer >= 1)
        {
            CheckMusic();
            checkTimer = 0;
        }
    }

    public void CheckMusic()
    {
        if (!audio.isPlaying && index < songs.Length-1)
        {
            index++;
            audio.clip = songs[index];
            audio.Play();
        }

        if (index > songs.Length - 1)
        {
            index = 0;
            audio.clip = songs[index];
            audio.Play();
        }
    }
}
