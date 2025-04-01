using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Sanity : MonoBehaviour
{
    public PostProcessVolume ppv;

    private Vignette vg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ppv.profile.TryGetSettings(out vg);
    }

    // Update is called once per frame
    void Update()
    {
        vg.intensity.value += Time.deltaTime/1000;
    }
}
