using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Sanity : MonoBehaviour
{
    public PostProcessVolume ppv;

    private Vignette vg;
    private ChromaticAberration chrom;
    public Grain grain;

    public int sanity; //goes up per loop, down when listen to therapy

    private int proggies;

    public GameObject[] pLights;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ppv.profile.TryGetSettings(out vg); //starts 45%
        ppv.profile.TryGetSettings(out chrom); //starts 50%
        ppv.profile.TryGetSettings(out grain); //starts 50%
    }

    // Update is called once per frame
    void Update()
    {
        proggies = FindFirstObjectByType<Player>().progress;

        if (sanity - proggies > 1)
        {
            vg.intensity.value += Time.deltaTime / (1000 / (sanity - proggies));
            chrom.intensity.value += Time.deltaTime / (1000 / (sanity - proggies));

            grain.intensity.value += Time.deltaTime / (1000 / (sanity - proggies));
            grain.size.value += Time.deltaTime / (1000 / (sanity - proggies));
        }
    }

    public void ProgUp()
    {
        pLights[proggies].SetActive(true);
    }
}