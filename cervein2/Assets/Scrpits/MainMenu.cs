using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class MainMenu : MonoBehaviour
{
    //strings
    public string LevelToLoad;
    //booleans
    public bool PlayGameSelected = false;
    public bool OptionsSelected = false;
    //floats
    public float PlayGameTimer = 0f;
    public float MaxPlayGameTimer;
    public float TestTimer;
    public float OptionsTimer;
    //GameObjects and Components
    public CanvasGroup FadeOut;
    //animation controllers
    public Animator MMOptionsAC;
    public Animator MMAC;
    //animations
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TestTimer += Time.deltaTime;
        if(TestTimer == 3)
        {

        }
        if(TestTimer == 6)
        {

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
        //MMOptionsButton
        if(OptionsSelected)
        {
            OptionsTimer += Time.deltaTime;
            MMOptionsAC.Play("MMOptionsMoveCenter");
            MMAC.Play("MMMainMenuMoveLeft");
        }
        if(OptionsTimer >= 0.5f && OptionsSelected)
        {
            MMOptionsAC.Play("MMOptionsStayCenter");
            MMAC.Play("MMMainMenuStayLeft");
            OptionsSelected = false;
            OptionsTimer = 0;
        }
    }
    public void MMPlayGame()
    {
        PlayGameSelected = true;
    }
    public void MMOptions()
    {
        OptionsSelected = true;
    }
    public void MMQuit()
    {
        Application.Quit();
    }
    public void OptionsBack()
    {

    }
    public void OptionsControls()
    {

    }
}
