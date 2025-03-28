using UnityEngine;

public class Anomaly : MonoBehaviour
{
    //anomaly functions:
    //move
    //appear
    //disappear
    //change
    [SerializeField] private int chance;
    
    [SerializeField] private bool move;
    [SerializeField] private Vector3 newPosition;
    
    [SerializeField] private GameObject obj;
    [SerializeField] private bool appear;
    [SerializeField] private bool disappear;
    
    [SerializeField] private bool change;
    [SerializeField] private GameObject otherObj;

    void OnBecameInvisible()
    {
        if (Random.Range(0, 100) < chance)
        {
            if (move)
            {
                transform.position = newPosition;
            }
            if (appear)
            {
                obj.SetActive(true);
            }
            if (disappear)
            {
                obj.SetActive(false);
            }

            if (change)
            {
                obj.SetActive(false);
                otherObj.SetActive(true);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}