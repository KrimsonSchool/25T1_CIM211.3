using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private bool cassette;
    [SerializeField] private AudioClip audioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindFirstObjectByType<ItemManager>().selectedItem == this)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindFirstObjectByType<ItemManager>().selectedItem = null;
                if (cassette)
                {
                    FindFirstObjectByType<CassettePlayer>().PlayAudio(audioClip);
                    Destroy(gameObject);
                }
            }
        }
    }
}
