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
    public float MVDBV;
    public float SFXDBV;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(MusicSlider != null)
        {
            MusicSlider.onValueChanged.AddListener(SetVolume1);
            if (MainMixer.GetFloat(volumeParameterName1, out float currentMixerValueMusic))
            {
                MusicSlider.value = Mathf.Pow(10, currentMixerValueMusic / 20);
            }
        }
        else
        {
            MVDBV = StoredInformation.MusicVolumeStatic;
        }
        if(SFXSlider != null)
        {
            SFXSlider.onValueChanged.AddListener(SetVolume2);
            if(MainMixer.GetFloat(volumeParameterName2, out float currentMixerValueSFX))
            {
                SFXSlider.value = Mathf.Pow(10, currentMixerValueSFX / 20);
            }
        }
        else
        {
            SFXDBV = StoredInformation.SFXVolumeStatic;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetVolume1(float MusicSliderValue)
    {
        //Music SetVolume;
        if(MusicSlider != null)
        {
            MVDBV = Mathf.Log10(MusicSliderValue) * 20;
            MainMixer.SetFloat(volumeParameterName1, MVDBV);
            StoredInformation.MusicVolumeStatic = MVDBV;
        }
    }
    public void SetVolume2(float SFXSliderValue)
    {
        //Music SetVolume;
        if(MusicSlider != null)
        {
            SFXDBV = Mathf.Log10(SFXSliderValue) * 20;
            MainMixer.SetFloat(volumeParameterName1, SFXDBV);
            StoredInformation.SFXVolumeStatic = SFXDBV;
        }
    }
}
