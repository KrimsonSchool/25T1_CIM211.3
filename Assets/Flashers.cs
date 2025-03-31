using UnityEngine;

public class Flashers : MonoBehaviour
{
    private float timer;

    public float time;

    public GameObject txt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            timer = 0;
            txt.SetActive(!txt.activeSelf);
        }
    }
}
