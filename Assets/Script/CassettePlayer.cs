using TMPro;
using UnityEngine;

public class CassettePlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    Light playerLight;

    [SerializeField] 
    GameObject captionArea;
    [SerializeField]
    TextMeshProUGUI captionText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying)
        {
            playerLight.color = Color.green;
            captionArea.SetActive(true);
        }
        else
        {
            playerLight.color = Color.red;
            captionArea.SetActive(false);
        }
    }

    public void PlayAudio(AudioClip audioClip, string caption)
    {
        audioSource.PlayOneShot(audioClip);
        captionText.text = caption;
    }
}
