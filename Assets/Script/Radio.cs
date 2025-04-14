using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEditor;

public class Radio : MonoBehaviour
{
   private AudioSource _audio;
    
    private string _path;
    public AudioClip[] songs;
    private int _index;

    private float _checkTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _path  = "Radio";

        /*if (SystemInfo.operatingSystem.Contains("Mac"))
        {
            _path = Application.dataPath + "/Resources/Data/StreamingAssets/Radio";
        }*/

        songs = Resources.LoadAll<AudioClip>(_path);
        
        //print(_path);
        //print(Resources.LoadAll(_path).Length);
        
        _audio.clip = songs[_index];
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _checkTimer += Time.deltaTime;
        if (_checkTimer >= _audio.clip.length)
        {
            CheckMusic();
            _checkTimer = 0;
        }
    }

    public void CheckMusic()
    {
        if (!_audio.isPlaying && _index < songs.Length-1)
        {
            _index++;
            _audio.clip = songs[_index];
            _audio.Play();
        }

        if (_index > songs.Length - 1)
        {
            _index = 0;
            _audio.clip = songs[_index];
            _audio.Play();
        }
    }
}
