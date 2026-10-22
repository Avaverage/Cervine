using UnityEngine;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour
{
    public CanvasGroup DeathCanvasGroup;
    public GameObject DeathCanvasGroupObject;
    public bool DeathScreenFadeIn = false;
    public CanvasGroup MainGameplayCanvasGroup;
    public CanvasGroup DeathText;
    public float FadeInTimer;
    public float MaxFadeInTimer;
    public string levelToLoad;
    public float TextFadeOutTimer;
    public float MaxTextFadeOutTimer;
    public FeedingDeer feedingDeer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(DeathCanvasGroup != null)
        {
            DeathCanvasGroup.enabled = false;
        }
        if(DeathCanvasGroupObject != null)
        {
            DeathCanvasGroupObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(DeathScreenFadeIn)
        {
            FadeInTimer += Time.deltaTime;
            if(DeathCanvasGroup != null)
            {
                DeathCanvasGroup.alpha = FadeInTimer / MaxFadeInTimer;
            }
            if(DeathCanvasGroupObject != null)
            {
                DeathCanvasGroupObject.SetActive(true);
            }
            if(FadeInTimer >= 6f)
            {
                SceneManager.LoadScene(levelToLoad);
            }
            if(FadeInTimer >= 4f)
            {
                TextFadeOutTimer -= Time.deltaTime;
                if(DeathText != null)
                {
                    DeathText.alpha = TextFadeOutTimer / MaxTextFadeOutTimer;
                }
            }
        }
    }
    public void OnDeath()
    {
        DeathScreenFadeIn = true;
        if(MainGameplayCanvasGroup != null)
        {
            MainGameplayCanvasGroup.alpha = 0;
        }
        if(DeathCanvasGroup != null)
        {
            DeathCanvasGroup.enabled = true;
            DeathCanvasGroup.alpha = 0;
        }
        StoredInformation.GameStart = false;
        if (feedingDeer != null) 
        {
            feedingDeer.TranslateInformation();
        }
    }
}
