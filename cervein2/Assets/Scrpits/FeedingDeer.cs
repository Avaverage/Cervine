using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeedingDeer : MonoBehaviour
{
    //integers
    public float DeerCrackerQuota;
    public float MaxDeerCrackerQuota;
    public float StartGameQuota;
    public float MaxStartGameQuota;
    public float startGameplayLoopTimer;
    public float maxStartGameplayLoopTimer;
    public int pointScore;
    public int pointScoreMarginalIncrease;
    //booleans
    public bool IsStartMenuDeer;
    //SpecialCondition.IsGameplayLoopStarted
    public bool IsGameplayLoopStarted;
    //Audio and what not
    public AudioClip ChompChompSFX;
    public AudioSource DeerAudioSource;
    //OutsideScripts
    public DeerPathfinding deerPathFinding;
    public NavMeshLootSpawner navMeshLootSpawner;
    public MainMenu mainMenuScript;
    public GameTimer gameTimer;
    public AudioManagment audioManagement;
    //UI
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI QuotaDisplay;
    public Image QuotaBar;
    public Image QuotaBarBackground;
    public TextMeshProUGUI DeerCrackersText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(scoreDisplay != null)
        {
            scoreDisplay.text = $"Score: {pointScore}".ToString();
        }
        StoredInformation.GameStart = false;
        IsGameplayLoopStarted = false;
        scoreDisplay.enabled = false;
        QuotaDisplay.enabled = false;
        QuotaBar.enabled = false;
        QuotaBarBackground.enabled = false;
        DeerCrackersText.enabled = false;
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
        if(StartGameQuota >= MaxStartGameQuota)
        {
            startGameplayLoopTimer += Time.deltaTime;
            if(startGameplayLoopTimer >= maxStartGameplayLoopTimer)
            {
                IsGameplayLoopStarted = true;
                scoreDisplay.enabled = true;
                QuotaDisplay.enabled = true;
                QuotaBar.enabled = true;
                QuotaBarBackground.enabled = true;
                DeerCrackersText.enabled = true;
                audioManagement.IsSecondPhase = true;
                audioManagement.Timer = 0f;
                startGameplayLoopTimer = 0f;
                StartGameQuota = 0;
            }
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
                if(!IsGameplayLoopStarted)
                {
                    StartGameQuota++;
                }
                else
                {
                    //Increase the amount of deer Crackers you've fed to the deer
                    DeerCrackerQuota++;
                    //Increase Score
                    pointScore += pointScoreMarginalIncrease;
                    //subtract count of deer crackers, according to the log
                    if(navMeshLootSpawner != null)
                    {
                        navMeshLootSpawner.deerCrackerTotalCount--;
                    }
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