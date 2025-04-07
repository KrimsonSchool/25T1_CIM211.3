using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType type;
    private AudioClip audioClip; //get from Resources
    private DiaryEntry diaryEntry; //get from Resources
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
                if (type == ItemType.Tape)
                {
                    FindFirstObjectByType<CassettePlayer>().PlayAudio(audioClip);
                    Destroy(gameObject);
                }

                if (type == ItemType.Diary)
                {
                    DiaryEntry[] allEntries = Resources.LoadAll<DiaryEntry>("DiaryEntries");
                    diaryEntry = allEntries[FindFirstObjectByType<Sanity>().sanity];
                    FindFirstObjectByType<DiaryReader>().Read(diaryEntry.entry);
                }
            }
        }
    }
}
