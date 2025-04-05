using System;
using UnityEngine;

public class DefaultSettings : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float rotSpeed;
    public float jumpHeight;

    public float slowdownSpeed;

    private Rigidbody rb;

    private bool inputting;
    bool grounded;

    public float grd;

    private Animator an;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        inputting = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        //print(grounded);

        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(
                transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical") +
                transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"), ForceMode.Impulse);
        }

        transform.Rotate(0, Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime, 0);

        if ((rb.linearVelocity.x + rb.linearVelocity.z) != 0)
        {
            an.SetBool("Run", true);

            if (!inputting)
            {
                rb.linearVelocity = Vector3.MoveTowards(rb.linearVelocity, new Vector3(0, rb.linearVelocity.y, 0),
                    slowdownSpeed * Time.deltaTime);
            }
        }
        else
        {
            an.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        //print(rb.linearVelocity.magnitude);

        //            rb.linearVelocity -= transform.right * Time.deltaTime * slowdownSpeed;
        Vector3 rayStart = transform.position + transform.up * 0.1f;

        Physics.Raycast(rayStart, -transform.up, out RaycastHit hit, grd, Physics.AllLayers);
        Debug.DrawRay(rayStart, -transform.up * grd, Color.red);

        //print(hit.distance);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }
        else
        {
            grounded = false;
        }

        if (!grounded)
        {
            an.SetBool("Fall", true);
        }
        else
        {
            an.SetBool("Fall", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            Destroy(other.gameObject);
        }
    }
}