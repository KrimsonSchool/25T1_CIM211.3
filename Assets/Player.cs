using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime) + (transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime, 0));
        Camera.main.gameObject.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime,0, 0));
    }
}
