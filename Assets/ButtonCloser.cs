using UnityEngine;

public class ButtonCloser : MonoBehaviour
{
    public GameObject toInteractWith;

    public void Close()
    {
        toInteractWith.SetActive(false);
    }
    public void Open()
    {
        toInteractWith.SetActive(true);
    }
}
