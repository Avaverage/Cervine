using UnityEngine;

public class AudioManagment : MonoBehaviour
{
    public AudioSource PlayerAudio;
    public AudioClip MMMusic;
    public bool IsMainMenu;
    public bool IsLevel;
    public float Timer;
    public float MaxMMMusicTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(IsMainMenu)
        {
            PlayerAudio.PlayOneShot(MMMusic);
        }
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
    }
}
