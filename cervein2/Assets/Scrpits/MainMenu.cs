using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //strings
    public string LevelToLoad;
    //booleans
    public bool PlayGameSelected = false;
    //floats
    public float PlayGameTimer = 0f;
    public float MaxPlayGameTimer;
    public float TestTimer;
    //GameObjects and Components
    public CanvasGroup FadeOut;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TestTimer += Time.deltaTime;
        if(TestTimer >= 3)
        {
            MMQuit();
        }
        if(PlayGameSelected)
        {
            PlayGameTimer += Time.deltaTime;
            FadeOut.alpha = PlayGameTimer / MaxPlayGameTimer;
            if (PlayGameTimer >= MaxPlayGameTimer)
            {
                SceneManager.LoadScene(LevelToLoad);
            }
        }
    }
    public void MMPlayGame()
    {
        PlayGameSelected = true;
    }
    public void MMOptions()
    {

    }
    public void MMQuit()
    {
        Application.Quit();
    }
}
