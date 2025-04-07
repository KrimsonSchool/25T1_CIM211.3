using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI itemText;
    [SerializeField] private TMPro.TextMeshProUGUI pickupText;

    [HideInInspector] public Item selectedItem;

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
            if (hit.collider.gameObject.CompareTag("Identifiable") &&
                Vector3.Distance(transform.position, hit.point) < 5)
            {
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    pickupText.text = "[E] to pickup";
                    selectedItem = hit.collider.gameObject.GetComponent<Item>();
                }
                else
                {
                    pickupText.text = "";
                    selectedItem = null;
                }

                itemText.text = hit.collider.gameObject.name;
            }
            else
            {
                itemText.text = "";
                pickupText.text = "";
                selectedItem = null;
            }
        }
        else
        {
            itemText.text = "";
            pickupText.text = "";
            selectedItem = null;
        }
    }
}