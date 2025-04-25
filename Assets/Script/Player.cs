using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotSpeed;

    private int _defaultFOV;
    private int _zoomFOV;

    private float _defaultGrainSize;
    private float _defaultGrainIntensity;

    private float _mousePitch;
    
    //STANDARDS:
    //PUBLIC = SOMETHING PLAYER CAN EDIT
    //PRIVATE = SOMETHING PLAYER CAN'T EDIT
    //SERIALIZED = SOMETHING THAT CAN BE EDITED IN EDITOR
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioClip[] zoomSounds;

    private bool _paused;
    public GameObject pauseMenu;

    public AudioSource camSource;



    [HideInInspector] public int progress; //mental progress to success
    
    void Start()
    {
        _defaultFOV = 60;
        _zoomFOV = 30;
        
        _defaultGrainSize = 1;
        _defaultGrainIntensity = 0.5f;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //print("pos x: " +Mathf.Abs(transform.position.x));
        
        transform.position += (transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime) + (transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime, 0));

        float mouseY = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        _mousePitch = Mathf.Clamp(_mousePitch - mouseY, -85f, 85f);
        Camera.main.transform.localEulerAngles = new Vector3(_mousePitch, 0, 0);
        
        // Camera.main.gameObject.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime,0, 0));

        if (Input.GetMouseButtonDown(1))
        {
            Camera.main.fieldOfView = _zoomFOV;
            FindAnyObjectByType<Sanity>().grain.intensity.value = 1;
            FindAnyObjectByType<Sanity>().grain.size.value = 2;
            
            camSource.PlayOneShot(zoomSounds[0]);
        }
        if(Input.GetMouseButtonUp(1))
        {
            Camera.main.fieldOfView = _defaultFOV;
            FindAnyObjectByType<Sanity>().grain.intensity.value = _defaultGrainIntensity;
            FindAnyObjectByType<Sanity>().grain.size.value = _defaultGrainSize;
            
            camSource.PlayOneShot(zoomSounds[1]);
        }

        if (Mathf.Abs(transform.position.x) > 10)
        {
            speed = 6 - (Mathf.Abs(transform.position.x) / 5);
            
            speed = Mathf.Clamp(speed, 0, 6);
            //if speed 0, fade to black, restart
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene("Menu");
            //pause menu
            if (!_paused)
            {
                Pause();
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                _paused = true;
                
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                UnPause();
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                _paused = false;
                
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        }

        if (progress >= 7)
        {
            //win!!!
            Win();
        }

        if (FindFirstObjectByType<Sanity>().sanity >= 10)
        {
            //Lose...
            Lose();
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

    public void Pause()
    {
        AudioSource[] asses = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        foreach (var ass in asses)
        {
            ass.Pause();
        }
    }

    public void UnPause()
    {
        AudioSource[] asses = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        foreach (var ass in asses)
        {
            ass.UnPause();
        }
    }







    public void Win()
    {
        SceneManager.LoadScene("EndingCutSceneGood");
    }

    public void Lose()
    {
        SceneManager.LoadScene("EndingCutsceneBad");
    }
}
