using UnityEngine;

public class Anomaly : MonoBehaviour
{
    void OnBecameInvisible()
    {
        transform.position += transform.up;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
