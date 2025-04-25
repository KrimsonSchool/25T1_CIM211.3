using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpener : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("END"))
        {
            Debug.Log("Hit");
            SceneManager.LoadScene("Menu");
        }
    }
}
