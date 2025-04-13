using UnityEngine;

public class Footstepaudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] footstepSounds; // Array to hold footstep sound clips
    private AudioSource audioSource;    // AudioSource component to play sounds
    private float walkSpeed = 1.5f;      // Speed of player walking
    private float nextStepTime = 1f;   // Time tracking to avoid overlapping footstep sounds

    void Start()
    {
        // Get the AudioSource component on the player
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing!");
        }
    }

    void Update()
    {
        // Check if the player is moving (and if they're walking, not running)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Time.time >= nextStepTime)
            {
                PlayRandomFootstep();
                nextStepTime = Time.time + (1f / walkSpeed); // Cooldown between footsteps
            }
        }
    }

    void PlayRandomFootstep()
    {
        // Play a random footstep sound
        if (footstepSounds.Length > 0)
        {
            AudioClip randomFootstep = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(randomFootstep);
        }
        else
        {
            Debug.LogWarning("No footstep sounds assigned!");
        }
    }
}
