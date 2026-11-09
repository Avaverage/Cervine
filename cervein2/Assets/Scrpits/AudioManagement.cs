using UnityEngine;

public class AudioManagment : MonoBehaviour
{
    public AudioSource PlayerAudio;
    public AudioClip MMMusic;
    public AudioClip LevelMusic;
    public AudioClip ChaosMusic;
    public AudioClip TensionChord;
    public bool IsMainMenu;
    public bool IsLevel;
    public bool IsSecondPhase;
    public bool OutOfDeerCrackers;
    public bool playTensionChord;
    public float Timer;
    float VolumeTimer;
    public float MaxVolumeTimer;
    public float MaxMMMusicTime;
    public float MaxChaosMusicTime;
    public float MaxLevelMusicTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(IsMainMenu)
        {
            PlayerAudio.PlayOneShot(MMMusic);
        }
        VolumeTimer = MaxVolumeTimer;
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
            if(Timer >= 52.364f)
            {
                Timer = 0;
            }
            if(OutOfDeerCrackers)
            {
                VolumeTimer -= Time.deltaTime;
                PlayerAudio.volume = VolumeTimer / MaxVolumeTimer;
                if(OutOfDeerCrackers && VolumeTimer >= 0)
                {
                    PlayerAudio.Stop();
                    PlayerAudio.volume = 1;
                    OutOfDeerCrackers = false;
                }
                if(VolumeTimer >= -2f)
                {
                    PlayerAudio.PlayOneShot(TensionChord);
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
}
