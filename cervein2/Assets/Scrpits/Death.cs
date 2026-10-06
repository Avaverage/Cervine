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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeathCanvasGroup.enabled = false;
        DeathCanvasGroupObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(DeathScreenFadeIn)
        {
            FadeInTimer += Time.deltaTime;
            DeathCanvasGroup.alpha = FadeInTimer / MaxFadeInTimer;
            DeathCanvasGroupObject.SetActive(true);
            if(FadeInTimer >= 6f)
            {
                SceneManager.LoadScene(levelToLoad);
            }
            if(FadeInTimer >= 4f)
            {
                TextFadeOutTimer -= Time.deltaTime;
                DeathText.alpha = TextFadeOutTimer / MaxTextFadeOutTimer;
            }
        }
    }
    public void OnDeath()
    {
        DeathScreenFadeIn = true;
        MainGameplayCanvasGroup.alpha = 0;
        DeathCanvasGroup.enabled = true;
        DeathCanvasGroup.alpha = 0;
    }
}
