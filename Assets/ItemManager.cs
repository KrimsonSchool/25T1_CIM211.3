using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI itemText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit);
        if (hit.collider != null)
        {
            itemText.text = hit.collider.gameObject.name;
        }
        else
        {
            itemText.text = "[Nothing in range]";
        }
    }
}
