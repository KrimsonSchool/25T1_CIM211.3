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
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 1, out RaycastHit hit);
        //check if is "ITEM"
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Identifiable"))
            {
                itemText.text = hit.collider.gameObject.name;
            }
            else
            {
                itemText.text = "";
            }
        }
        else
        {
            itemText.text = "";
        }
    }
}
