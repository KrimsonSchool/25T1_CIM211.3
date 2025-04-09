using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType type;
    private AudioClip audioClip; //get from Resources

    private DiaryEntry diaryEntry; //get from Resources
    
    ItemManager itemManager;

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
            FindFirstObjectByType<CassettePlayer>().PlayAudio(audioClip);
            Destroy(gameObject);
        }

        if (type == ItemType.Diary)
        {
            DiaryEntry[] allEntries = Resources.LoadAll<DiaryEntry>("DiaryEntries");
            print(allEntries.Length);
            if (!allEntries[FindFirstObjectByType<Sanity>().sanity].read)
            {
                diaryEntry = allEntries[FindFirstObjectByType<Sanity>().sanity];
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