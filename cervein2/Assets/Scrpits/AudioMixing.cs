using UnityEngine;
using UnityEngine.Audio;

public class AudioMixing : MonoBehaviour
{
    [SerializeField] public AudioMixer MainMixer;
    [SerializeField] public static string volumeParameterName1 = "MusicVolume";
    [SerializeField] public static string volumeParameterName2 = "SFXVolume";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVolume(float linearValue)
    {
        //Music SetVolume;
        float MVClamped = Mathf.Clamp(linearValue, 0.0001f, 1f);
        float MVDBV = Mathf.Log10(MVClamped) * 20;
        //SFX SetVolume
        float SFXVClamped = Mathf.Clamp(linearValue, 0.0001f, 1f);
        float SFXVDBV = Mathf.Log10(SFXVClamped) * 20;
    }
}
