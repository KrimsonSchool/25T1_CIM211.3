using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Sanity : MonoBehaviour
{
    public PostProcessVolume ppv;

    private Vignette vg;
    private ChromaticAberration chrom;
    public Grain grain;

    public int sanity;//goes up per loop, down when listen to therapy
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ppv.profile.TryGetSettings(out vg);//starts 45%
        ppv.profile.TryGetSettings(out chrom);//starts 50%
        ppv.profile.TryGetSettings(out grain);//starts 50%
        //grain                               //starts 50%
    }

    // Update is called once per frame
    void Update()
    {
        vg.intensity.value += Time.deltaTime/(1000/(sanity+1));
        chrom.intensity.value += Time.deltaTime/(1000/(sanity+1));
        
        
    }
}
