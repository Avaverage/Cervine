using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class FeedingDeer : MonoBehaviour
{
    //integers
    public int DeerCrackerQuota;
    public int MaxDeerCrackerQuota;
    public int pointScore;
    public int pointScoreMarginalIncrease;
    //floats
    //Audio and what not
    public AudioClip ChompChompSFX;
    public AudioSource DeerAudioSource;
    //OutsideScripts
    public DeerPathfinding deerPathFinding;
    //UI
    public TextMeshProUGUI scoreDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreDisplay.text = $"Score: {pointScore}".ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameTimer.MainTimer <= 0f)
        {
            deerPathFinding.IsDeerUpset = true;
        }
    }
    //OnTriggerEnter is called every time the object the code is applied to makes valid collision with another object. Triggers allow for non-physical collisions
    void OnTriggerEnter(Collider Collision)
    {
        if(Collision.gameObject.CompareTag("DeerCracker"))
        {
            //Increase the amount of deer Crackers you've fed to the deer
            DeerCrackerQuota++;
            //Play Some SFX (Maybe I'll add particle effects too, but I haven't dabbled in that art yet)
            if(ChompChompSFX != null)
            {
                DeerAudioSource.PlayOneShot(ChompChompSFX);
            }
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
            pointScore += pointScoreMarginalIncrease;
            scoreDisplay.text = $"Score: {pointScore}".ToString();
        }
    }
}
//Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom . . . etc . . .