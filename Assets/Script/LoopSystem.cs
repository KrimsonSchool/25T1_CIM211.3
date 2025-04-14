using System;
using UnityEngine;

public class LoopSystem : MonoBehaviour
{
    public event Action SanityRose;
    private int loop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loop()
    {
        SanityRose?.Invoke();
        
        loop++;
        FindFirstObjectByType<Sanity>().sanity++;
        
        Anomaly[] anomalies = FindObjectsOfType<Anomaly>();
        foreach (var anomaly in anomalies)
        {
            anomaly.LoopCheck(loop);
        }
    }
}
