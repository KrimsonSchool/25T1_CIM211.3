using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotSpeed;

    private int defaultFOV;
    private int zoomFOV;
    
    
    //STANDARDS:
    //PUBLIC = SOMETHING PLAYER CAN EDIT
    //PRIVATE = SOMETHING PLAYER CAN'T EDIT
    //SERIALIZED = SOMETHING THAT CAN BE EDITED IN EDITOR
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        defaultFOV = 60;
        zoomFOV = 30;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print("pos x: " +Mathf.Abs(transform.position.x));
        
        transform.position += (transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime) + (transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime, 0));
        
        Camera.main.gameObject.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime,0, 0));

        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = zoomFOV;
        }
        else
        {
            Camera.main.fieldOfView = defaultFOV;
        }

        if (Mathf.Abs(transform.position.x) > 10)
        {
            speed = 6 - (Mathf.Abs(transform.position.x) / 5);
            
            speed = Mathf.Clamp(speed, 0, 6);
            //if speed 0, fade to black, restart
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(1);
        }

        if (other.CompareTag("Forward"))
        {
            transform.position = new Vector3(transform.position.x,1, transform.position.z-120);
            FindFirstObjectByType<LoopSystem>().Loop();
        }
        if (other.CompareTag("Backward"))
        {
            transform.position = new Vector3(transform.position.x,1, transform.position.z+120);
        }
    }
}
