using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeedingDeer : MonoBehaviour
{
    //integers
    public float DeerCrackerQuota;
    public float MaxDeerCrackerQuota;
    public int pointScore;
    public int pointScoreMarginalIncrease;
    //booleans
    public bool IsStartMenuDeer;
    //Audio and what not
    public AudioClip ChompChompSFX;
    public AudioSource DeerAudioSource;
    //OutsideScripts
    public DeerPathfinding deerPathFinding;
    public NavMeshLootSpawner navMeshLootSpawner;
    public MainMenu mainMenuScript;
    //UI
    public TextMeshProUGUI scoreDisplay;
    public GameTimer gameTimer;
    public TextMeshProUGUI QuotaDisplay;
    public Image QuotaBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(scoreDisplay != null)
        {
            scoreDisplay.text = $"Score: {pointScore}".ToString();
        }
        StoredInformation.GameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(deerPathFinding != null)
        {
            if (gameTimer.MainTimer < 0f)
            {
                deerPathFinding.IsDeerUpset = true;
            }
            if(gameTimer.MainTimer > 0f)
            {
                deerPathFinding.IsDeerUpset = false;
            }
        }
        if(scoreDisplay != null)
        {
            scoreDisplay.text = $"Score: {pointScore}".ToString();
        }
        if (DeerCrackerQuota >= MaxDeerCrackerQuota)
        {
            if(gameTimer != null)
            {
                gameTimer.MaxTimer -= 5f;
                gameTimer.MainTimer = gameTimer.MaxTimer;
            }
            //Make the deer no longer upset
            if(deerPathFinding != null)
            {
                deerPathFinding.IsDeerUpset = false;
            }
            //Increase The Maximum Amount of Deer Crackers Needed To satisfy the Deer's hunger
            MaxDeerCrackerQuota++;
            DeerCrackerQuota = 0;
        }
        if(QuotaDisplay != null)
        {
            QuotaDisplay.text = ($"{DeerCrackerQuota}/{MaxDeerCrackerQuota}");
        }
        if(QuotaBar != null)
        {
        QuotaBar.fillAmount = DeerCrackerQuota / MaxDeerCrackerQuota;
        }
    }
    //OnTriggerEnter is called every time the object the code is applied to makes valid collision with another object. Triggers allow for non-physical collisions
    void OnTriggerEnter(Collider Collision)
    {
        if(Collision.gameObject.CompareTag("DeerCracker"))
        {
            if(IsStartMenuDeer)
            {
                if(mainMenuScript != null)
                {
                    mainMenuScript.MMPlayGame();
                }
            }
            else
            {
                //Increase the amount of deer Crackers you've fed to the deer
                DeerCrackerQuota++;

                pointScore += pointScoreMarginalIncrease;
                if(navMeshLootSpawner != null)
                {
                    navMeshLootSpawner.deerCrackerTotalCount--;
                }
            }
            //Play Some SFX (Maybe I'll add particle effects too, but I haven't dabbled in that art yet)
            if(ChompChompSFX != null)
            {
                if(DeerAudioSource != null && ChompChompSFX != null)
                {
                    DeerAudioSource.PlayOneShot(ChompChompSFX);
                }

            }
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