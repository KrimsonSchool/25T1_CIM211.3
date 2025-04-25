using UnityEngine;

public class EndScene : MonoBehaviour
{
    public float speed = 5f; // Speed of movement

    void Update()
    {
        // Move the object forward along its z-axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
