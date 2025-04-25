using UnityEngine;

public class EndScenePopupBad : MonoBehaviour
{
    public GameObject EndingBadPopUp;
    private CanvasGroup canvasGroup;
    public float fadeDuration = 1.5f;

    void Start()
    {
        canvasGroup = EndingBadPopUp.GetComponent<CanvasGroup>();
        EndingBadPopUp.SetActive(false);
        canvasGroup.alpha = 0f; // Fully transparent
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Girl"))
        {
            Debug.Log("Hit");
            EndingBadPopUp.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    System.Collections.IEnumerator FadeIn()
    {
        float time = 0f;
        while (time < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f; // Ensure it's fully visible
    }
}