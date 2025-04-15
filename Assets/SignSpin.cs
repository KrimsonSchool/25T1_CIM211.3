using UnityEngine;

public class SignSpin : MonoBehaviour
{
    public Texture[] signs;
    public Material signMat;

    private float timer;
    public float max;

    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        max = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > max)
        {
            index++;
            if (index > signs.Length-1)
            {
                index = 0;
            }
            
            signMat.SetTexture("_MainTex", signs[index]);
            
            timer = 0;
        }
    }
}
