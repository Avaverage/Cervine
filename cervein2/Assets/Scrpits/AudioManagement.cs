using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagment : MonoBehaviour
{
    public AudioSource PlayerAudio;
    public AudioSource PlayerAudio2;
    public AudioSource PlayerAudio3;
    public AudioClip MMMusic;
    public AudioClip LevelMusic;
    public AudioClip ChaosMusic;
    public AudioClip TensionChord;
    public AudioClip ButtonPress;
    public Image EYEBROWS;
    public CanvasGroup EYEBROWSCanvasGroup;

    public bool IsMainMenu;
    public bool IsLevel;
    public bool IsSecondPhase;
    public bool OutOfDeerCrackers;
    public bool playTensionChord;
    public float TimerTolerance = 0.01f;
    public float Timer;
    public float VolumeTimer;
    public float MaxVolumeTimer;
    public float MaxMMMusicTime;
    public float MaxChaosMusicTime;
    public float MaxLevelMusicTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EYEBROWS.enabled = false;
        if(IsMainMenu)
        {
            PlayerAudio.PlayOneShot(MMMusic);
        }
        VolumeTimer = MaxVolumeTimer;
        if(IsLevel)
        {
            PlayerAudio.PlayOneShot(LevelMusic);
        }
        PlayerAudio2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsMainMenu)
        {
            Timer += Time.deltaTime;
            if(Timer >= MaxMMMusicTime)
            {
                PlayerAudio.PlayOneShot(MMMusic);
                Timer = 0;
            }
        }
        if(IsLevel)
        {
            Timer += Time.deltaTime;
            if(Timer == 0f)
            {
                PlayerAudio.PlayOneShot(LevelMusic);
            }
            if(Timer >= MaxLevelMusicTime)
            {
                Timer = 0;
            }
            if(OutOfDeerCrackers)
            {
                VolumeTimer -= Time.deltaTime;
                PlayerAudio.volume = VolumeTimer / MaxVolumeTimer;
                if(OutOfDeerCrackers && VolumeTimer <= -3f)
                {
                    PlayerAudio.Stop();
                    PlayerAudio.volume = 1;
                    OutOfDeerCrackers = false;
                }
                if(Mathf.Abs(VolumeTimer - -2f) <= TimerTolerance)
                {
                    PlayerAudio3.PlayOneShot(TensionChord);
                    EYEBROWS.enabled = true;
                    StartCoroutine(FadeOutEyebrows());
                }
                if(VolumeTimer <= -2f)
                {

                }
            }
            if(IsSecondPhase)
            {
                if(Timer == 0)
                {
                    PlayerAudio.PlayOneShot(ChaosMusic);
                }
                if(Timer >= MaxChaosMusicTime)
                {
                    Timer = 0;
                }
            }
            else
            {
                if(Timer == 0)
                {
                    PlayerAudio.PlayOneShot(LevelMusic);
                }
                if(Timer >= MaxLevelMusicTime)
                {
                    Timer = 0;
                }
            }
        }
    }
    public IEnumerator FadeOutEyebrows()
    {
        while(VolumeTimer > -3)
        {
            EYEBROWSCanvasGroup.alpha -= 0.016666f;
            yield return null;
        }
    }
    public void ChaosMusicStarted()
    {
        PlayerAudio2.enabled = true;
    }
    public void ButtonPressSFX()
    {
        PlayerAudio3.PlayOneShot(ButtonPress);
    }
}
