using JetBrains.Annotations;
using UnityEngine;

public class FeedingDeer : MonoBehaviour
{
    //integers
    public int DeerCrackerQuota;
    public int MaxDeerCrackerQuota;
    public int pointScore;
    //floats
    //Audio and what not
    public AudioClip ChompChompSFX;
    public AudioSource DeerAudioSource;
    //OutsideScripts
    public DeerPathfinding deerPathFinding;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameTimer.MainTimer <= 0f)
        {
            deerPathFinding.IsDeerUpset = true;
        }
    }
    void OnTriggerEnter(Collider Collision)
    {
        if(Collision.gameObject.CompareTag("DeerCracker"))
        {
            //Increase the amount of deer Crackers you've fed to the deer
            DeerCrackerQuota++;
            //Play Some SFX (Maybe I'll add particle effects too, but I haven't dabbled in that art yet)
            DeerAudioSource.PlayOneShot(ChompChompSFX);
            //if You get enough Deer Crackers
            if (DeerCrackerQuota >= MaxDeerCrackerQuota)
            {
                //Increase The Maximum Amount of Deer Crackers Needed To satisfy the Deer's hunger
                MaxDeerCrackerQuota++;
                DeerCrackerQuota = 0;
                GameTimer.MainMaxTimer *= (GameTimer.NewMaxTimer);
                GameTimer.MainTimer = GameTimer.MainMaxTimer;
            }
            //destroy DeerCracker
            Destroy(Collision.gameObject);
            //Add to point score. Can maybe display it somewhere in the UI
            pointScore += 100;
        }
    }
}
