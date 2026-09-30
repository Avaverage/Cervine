using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixing : MonoBehaviour
{
    [SerializeField] public AudioMixer MainMixer;
    [SerializeField] public static string volumeParameterName1 = "Music Volume";
    [SerializeField] public static string volumeParameterName2 = "SFX Volume";
    [SerializeField] public Slider MusicSlider;
    [SerializeField] public Slider SFXSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MusicSlider.onValueChanged.AddListener(SetVolume1);
        if (MainMixer.GetFloat(volumeParameterName1, out float currentMixerValueMusic))
        {
            MusicSlider.value = Mathf.Pow(10, currentMixerValueMusic / 20);
        }
        SFXSlider.onValueChanged.AddListener(SetVolume2);
        if(MainMixer.GetFloat(volumeParameterName2, out float currentMixerValueSFX))
        {
            SFXSlider.value = Mathf.Pow(10, currentMixerValueMusic / 20);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetVolume1(float MusicSliderValue)
    {
        //Music SetVolume;
        float MVDBV = Mathf.Log10(MusicSliderValue) * 20;
        MainMixer.SetFloat(volumeParameterName1, MVDBV);
    }
    public void SetVolume2(float SFXSliderValue)
    {
        //Music SetVolume;
        float SFXDBV = Mathf.Log10(SFXSliderValue) * 20;
        MainMixer.SetFloat(volumeParameterName1, SFXDBV);
    }
}
