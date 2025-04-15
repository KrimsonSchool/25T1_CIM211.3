using System;
using UnityEngine;
using UnityEngine.Serialization;

public class RandomLoc : MonoBehaviour
{
    LoopSystem sanityEvent;

    void Awake()
    {
        sanityEvent = FindFirstObjectByType<LoopSystem>();
        //when sanity var changes  ->  Randomize()
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Randomise()
    {
        GameObject[] locs = GameObject.FindGameObjectsWithTag(tagged);
        int rng = UnityEngine.Random.Range(0, locs.Length);
        transform.position = locs[rng].transform.position;
        transform.rotation = locs[rng].transform.rotation;
        
        print("Randomising loc out of " + locs.Length);
        
        transform.GetChild(0).gameObject.SetActive(true);
    }


    public string tagged;

    private void OnEnable()
    {
        sanityEvent.SanityRose += Randomise;
    }

    // Same as above but unsubscribing so you don't trigger when the game object isn't enabled
    private void OnDisable()
    {
        sanityEvent.SanityRose -= Randomise;
    }
}