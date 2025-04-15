using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class SettingsMenu : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderText;

    private Player _plr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _plr = FindFirstObjectByType<Player>();
        slider.value = _plr.rotSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        sliderText.text = _plr.rotSpeed +"/"+slider.maxValue;
        _plr.rotSpeed = slider.value;
    }

    public void CloseSettings()
    {
        gameObject.SetActive(false);
    }
}
