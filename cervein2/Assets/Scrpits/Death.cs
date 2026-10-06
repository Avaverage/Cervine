using UnityEngine;

public class Death : MonoBehaviour
{
    public CanvasGroup DeathCanvasGroup;
    public bool DeathScreenFadeIn = false;
    public CanvasGroup MainGameplayCanvasGroup;
    public float FadeInTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeathCanvasGroup.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(DeathScreenFadeIn)
        {
            FadeInTimer += Time.deltaTime;
        }
    }
    public void OnDeath()
    {
        DeathScreenFadeIn = true;
        MainGameplayCanvasGroup.enabled = false;
        DeathCanvasGroup.enabled = true;
        DeathCanvasGroup.alpha = 0;
    }
}
