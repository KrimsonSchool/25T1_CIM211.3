using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _snk : MonoBehaviour
{
    public float spd;
    public float spd_m;
    public float jph;

    public Material[] mtl;

    private bool jpd;

    private MeshRenderer mrd;

    public float grd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mrd = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") !=0)
        {
            if (spd < spd_m && spd > -spd_m)
            {
                spd += Input.GetAxis("Horizontal");
            }
            else
            {
                spd = Mathf.Round(spd);
            }
        }
        else
        {
            if (spd > 0)
            {
                spd -= 2;
                spd = Mathf.Round(spd);
            }
            else if(spd<0)
            {
                spd += 2;
                spd = Mathf.Round(spd);
            }
        }
        
        transform.position += transform.right * spd/10 * Time.deltaTime;



        if (Input.GetKey(KeyCode.Space) && !jpd)
        {
            jpd = true;
            //transform.position += transform.up * jph;
            GetComponent<Rigidbody>().AddForce(0, jph, 0, ForceMode.Impulse);
            
            mrd.material = mtl[1];
        }

        if (jpd)
        {
            Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, grd);
            Debug.DrawRay(transform.position, -transform.up * grd, Color.red);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Ground")
                {
                    jpd = false;
                    mrd.material = mtl[0];
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.tag == "Win")
        {
            SceneManager.LoadScene(0);
        }
    }
}
