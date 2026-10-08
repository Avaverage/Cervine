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
    public GameTimer gameTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreDisplay.text = $"Score: {pointScore}".ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer.MainTimer < 0f)
        {
            deerPathFinding.IsDeerUpset = true;
        }
        if(gameTimer.MainTimer > 0f)
        {
            deerPathFinding.IsDeerUpset = false;
        }
        scoreDisplay.text = $"Score: {pointScore}".ToString();
        if (DeerCrackerQuota >= MaxDeerCrackerQuota)
        {
            gameTimer.MaxTimer -= 5f;
            gameTimer.MainTimer = gameTimer.MaxTimer;
            //Make the deer no longer upset
            deerPathFinding.IsDeerUpset = false;
            //Increase The Maximum Amount of Deer Crackers Needed To satisfy the Deer's hunger
            MaxDeerCrackerQuota++;
            DeerCrackerQuota = 0;
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
            pointScore += pointScoreMarginalIncrease;


            //if You get enough Deer Crackers

            //destroy DeerCracker
            Destroy(Collision.gameObject);
            //Add to point score. Can maybe display it somewhere in the UI
        }
    }
    public void TranslateInformation()
    {
        StoredInformation.EndgameScore = pointScore;
    }
}
//Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom Nom . . . etc . . .