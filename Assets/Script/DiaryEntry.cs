using UnityEngine;

public class DiaryEntry : MonoBehaviour
{
    [TextArea(6, 18)]
    public string entry;

    public bool read;
}
