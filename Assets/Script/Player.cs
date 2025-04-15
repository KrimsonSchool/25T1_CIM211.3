using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotSpeed;

    private int defaultFOV;
    private int zoomFOV;

    private float defaultGrainSize;
    private float defaultGrainIntensity;
    //STANDARDS:
    //PUBLIC = SOMETHING PLAYER CAN EDIT
    //PRIVATE = SOMETHING PLAYER CAN'T EDIT
    //SERIALIZED = SOMETHING THAT CAN BE EDITED IN EDITOR
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    
    void Start()
    {
        defaultFOV = 60;
        zoomFOV = 30;
        
        defaultGrainSize = 1;
        defaultGrainIntensity = 0.5f;
        
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
            FindAnyObjectByType<Sanity>().grain.intensity.value = 1;
            FindAnyObjectByType<Sanity>().grain.size.value = 2;
        }
        else
        {
            Camera.main.fieldOfView = defaultFOV;
            FindAnyObjectByType<Sanity>().grain.intensity.value = defaultGrainIntensity;
            FindAnyObjectByType<Sanity>().grain.size.value = defaultGrainSize;

        }

        if (Mathf.Abs(transform.position.x) > 10)
        {
            speed = 6 - (Mathf.Abs(transform.position.x) / 5);
            
            speed = Mathf.Clamp(speed, 0, 6);
            //if speed 0, fade to black, restart
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
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
