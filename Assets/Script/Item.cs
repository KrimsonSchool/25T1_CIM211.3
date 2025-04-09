using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType type;
    private AudioClip audioClip; //get from Resources

    private DiaryEntry diaryEntry; //get from Resources
    
    ItemManager itemManager;


    private int sanity;
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
            sanity = FindFirstObjectByType<Sanity>().sanity;
            
            if (type == ItemType.Diary)
            {
                if (diaryEntry != null)
                {
                    if (diaryEntry.read)
                    {
                        gameObject.name = "Diary (READ)";
                    }
                    else
                    {
                        gameObject.name = "Diary";
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
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
            
            Destroy(gameObject);
        }
        if (type == ItemType.Diary)
        {
            DiaryEntry[] allEntries = Resources.LoadAll<DiaryEntry>("DiaryEntries");
            if (!allEntries[sanity].read)
            {
                diaryEntry = allEntries[sanity];
            }
            else
            {
                return;
            }

            diaryEntry.read = true;
            FindFirstObjectByType<DiaryReader>().Read(diaryEntry.entry);
        }
    }
}