using TMPro;
using UnityEngine;

public class DiaryReader : MonoBehaviour
{
    private float timer;
    public float speed;
    
    bool hasText = false;

    private int index;
    private int indexMax;

    private char[] chars;

    public TextMeshProUGUI diaryText;
    public GameObject diary;
    
    string fullText;

    private AudioClip[] clips;

    private AudioSource ass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Read("This is a test of the diary entry system.");
        clips = Resources.LoadAll<AudioClip>("TextSounds");
        ass = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasText && Input.GetKeyDown(KeyCode.Space))
        {
            diary.SetActive(false);
        }
        
        if (hasText)
        {
            diary.SetActive(true);
            
            timer += Time.deltaTime;

            if (timer >= speed)
            {
                timer = 0;
                
                diaryText.text += chars[index];
                ass.PlayOneShot(clips[Random.Range(0, clips.Length)]);
                
                if (index < indexMax)
                {
                    index++;
                }
                else
                {
                    hasText = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                diaryText.text = "";
                diaryText.text = fullText;
                hasText = false;
            }
        }

    }

    public void Read(string text)
    {
        diaryText.text = "";

        index = 0;
        
        chars = text.ToCharArray();
        indexMax = chars.Length-1;
        hasText = true;

        fullText = text;
    }
}
