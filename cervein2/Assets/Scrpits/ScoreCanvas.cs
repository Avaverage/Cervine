using System.Collections;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreCanvas : MonoBehaviour
{
    public float CurrentCount;
    public float CCMarginalIncrease;
    public float ScoreMaxValue;
    public float Timer;
    public bool CountUpYetToStart = true;
    public bool CanvasAnimationsStarted = false;
    public bool CanvasAnimationsEnded = false;
    public GameObject NewHighScoreText;
    public TextMeshProUGUI ScoreDisplay;
    public Animator CanvasGroupButtons;
    public TextMeshProUGUI HighScoreDisplay;
    public float CurrentHighScore;
    public bool MainMenuSelectedBool;
    public float FadeOutTimer;
    public CanvasGroup FadeOut;
    public StoredInformation storedInformation;
    public string LevelToLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreMaxValue = StoredInformation.EndgameScore;
        //Adjust the Marginal Increase to add up to the endgame score in a set amount of time
        CCMarginalIncrease = StoredInformation.EndgameScore / 60f / 5f;
        //Set Proper Animation
        CanvasGroupButtons.Play("GoneStatic");
        if(StoredInformation.EndgameScore > StoredInformation.HighScoreStatic)
        {
            NewHighScoreText.SetActive(true);
            StoredInformation.HighScoreStatic = StoredInformation.EndgameScore;
        }
        CurrentHighScore = StoredInformation.HighScoreStatic;
    }
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= 3 )
        {
            StartCoroutine(CountUpRoutine());
            CountUpYetToStart = false;
        }
        if (Timer >= 8f && !CanvasAnimationsStarted)
        {
            CanvasGroupButtons.Play("AppearingMove");
            CurrentHighScore = StoredInformation.HighScoreStatic;
            CanvasAnimationsStarted = true;
        }
        if(Timer >= 8.5f && !CanvasAnimationsEnded)
        {
            CanvasGroupButtons.Play("AppearingStatic");
            CanvasAnimationsStarted = true;
        }
        ScoreDisplay.text = ($"{CurrentCount}");
        HighScoreDisplay.text = ($"(High Score: {CurrentHighScore})");
        if(MainMenuSelectedBool)
        {
            FadeOutTimer += Time.deltaTime;
            FadeOut.alpha = FadeOutTimer / 3;
            if(FadeOutTimer >= 3)
            {
                SceneManager.LoadScene(LevelToLoad);
            }
        }
        if(CurrentCount > ScoreMaxValue)
        {
            CurrentCount = ScoreMaxValue;
        }
    }
    public IEnumerator CountUpRoutine()
    {
        while(CurrentCount < ScoreMaxValue)
        {
            //Add to the current count;
            CurrentCount += CCMarginalIncrease;
            //log it
            Debug.Log($"CurrentCount: {CurrentCount}");
            //return for the next frame and do it again.
            yield return null;
        }
    }
    public void MainMenuSelected()
    {
        MainMenuSelectedBool = true;
        storedInformation.OnSave();
    }
}
