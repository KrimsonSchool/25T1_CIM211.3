using UnityEngine;

public class MatScroll : MonoBehaviour
{
    public Material mat;

    public float speed;
    float offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
