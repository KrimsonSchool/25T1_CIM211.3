using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Sanity : MonoBehaviour
{
    public PostProcessVolume ppv;

    private Vignette vg;
    private ChromaticAberration chrom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ppv.profile.TryGetSettings(out vg);//starts 45%
        ppv.profile.TryGetSettings(out chrom);//starts 50%
        //grain                               //starts 50%
    }

    // Update is called once per frame
    void Update()
    {
        vg.intensity.value += Time.deltaTime/1000;
        chrom.intensity.value += Time.deltaTime/1000;
    }
}
