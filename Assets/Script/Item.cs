using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType type;
    private AudioClip audioClip; //get from Resources

    private DiaryEntry diaryEntry; //get from Resources

    ItemManager itemManager;


    private int sanity;

    private DiaryEntry[] allEntries;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemManager = FindFirstObjectByType<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemManager.selectedItem == this)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {        
                sanity = FindFirstObjectByType<Sanity>().sanity;
                CheckItem();
            }
        }
    }


    public void CheckItem()
    {
        FindFirstObjectByType<ItemManager>().selectedItem = null;

        if (type == ItemType.Tape)
        {
            AudioClip[] allClips = Resources.LoadAll<AudioClip>("Tapes");
            audioClip = allClips[sanity];
            FindFirstObjectByType<CassettePlayer>().PlayAudio(audioClip);
        }

        if (type == ItemType.Diary)
        {
            allEntries = Resources.LoadAll<DiaryEntry>("DiaryEntries");

            diaryEntry = allEntries[sanity];

            FindFirstObjectByType<DiaryReader>().Read(diaryEntry.entry);
        }
    }
}