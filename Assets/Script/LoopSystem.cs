using UnityEngine;

public class LoopSystem : MonoBehaviour
{
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
        loop++;
        FindFirstObjectByType<Sanity>().sanity++;
        
        Anomaly[] anomalies = GameObject.FindObjectsOfType<Anomaly>();
        foreach (var anomaly in anomalies)
        {
            anomaly.LoopCheck(loop);
        }
    }
}
