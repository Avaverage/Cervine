using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.Scripting;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    //strings
    public string LevelToLoad;
    public string OtherLevelToLoad;
    //booleans
    public bool PlayGameSelected = false;
    public bool OptionsSelected = false;
    public bool MMSelected = true;
    bool TestTimerActive = true;
    public bool OptionsBackActive = false;
    public bool OptionsControlsActive = false;
    public bool OptionsControlsInactive = false;
    public bool PlayTutorialSelected = false;
    //floats
    public float PlayGameTimer = 0f;
    public float FadeInTimer = 3;
    public float MaxPlayGameTimer;
    public float TestTimer;
    public float OptionsTimer;
    //GameObjects and Components
    public CanvasGroup FadeOut;
    public CanvasGroup FadeIn;
    public CanvasGroup Controls;
    //animation controllers
    public Animator MMOptionsAC;
    public Animator MMAC;
    public Animator OptionsControlsAC;
    //scripts
    public StoredInformation StoredInformation;
    //animations
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MMSelected = true;
        Controls.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        FadeInTimer -= Time.deltaTime;
        FadeIn.alpha = FadeInTimer / 3;
        if(MMSelected)
        {
            OptionsSelected = false;
        }
        TestTimer += Time.deltaTime;
        if(TestTimer >= 3 && TestTimerActive)
        {

            TestTimerActive = false;
        }
        if(TestTimer == 6)
        {

        }
        if(PlayGameSelected || PlayTutorialSelected)
        {
            PlayGameTimer += Time.deltaTime;
            FadeOut.alpha = PlayGameTimer / MaxPlayGameTimer;
            if (PlayGameTimer >= MaxPlayGameTimer)
            {
                StoredInformation.OnSave();
                if(PlayGameSelected)
                {
                    SceneManager.LoadScene(LevelToLoad);
                }
                if(PlayTutorialSelected)
                {
                    SceneManager.LoadScene(OtherLevelToLoad);
                }
            }
        }
        //MMOptionsButton
        if(OptionsSelected)
        {
            OptionsTimer += Time.deltaTime;
            MMOptionsAC.Play("MMOptionsMoveCenter");
            MMAC.Play("MMMainMenuMoveLeft");
            if(OptionsTimer >= 0.5f && OptionsSelected)
            {
                MMOptionsAC.Play("MMOptionsStayCenter");
                MMAC.Play("MMMainMenuStayLeft");
                OptionsSelected = false;
                OptionsTimer = 0;
            }
        }
        //Options Back Button
        if(OptionsBackActive)
        {
            OptionsTimer += Time.deltaTime;
            MMOptionsAC.Play("MMOptionsMoveLeft");
            MMAC.Play("MMMainMenuMoveCenter");
            if (OptionsTimer >= 0.5f && OptionsBackActive)
            {
                MMOptionsAC.Play("MMOptionsStayLeft");
                MMAC.Play("MMMainMenuActive");
                OptionsBackActive = false;
                OptionsTimer = 0;
            }
        }
        //Options Controls Button
        if (OptionsControlsActive)
        {
            OptionsTimer += Time.deltaTime;
            Controls.enabled = true;
            OptionsControlsAC.Play("ControlsMovingOpen");
            if (OptionsControlsActive && OptionsTimer >= 0.5f)
            {
                OptionsControlsAC.Play("ControlsOpen");
                OptionsControlsActive = false;
                OptionsTimer = 0;
            }
        }
        //Controls Back Button
        if(OptionsControlsInactive)
        {
            OptionsTimer += Time.deltaTime;
            OptionsControlsAC.Play("ControlsMovingClose");
            if(OptionsControlsInactive & OptionsTimer >= 0.05f)
            {
                OptionsControlsAC.Play("ControlsClose");
                Controls.enabled = false;
                OptionsControlsInactive = false;
                OptionsTimer = 0;
            }
        }
    }
    public void MMPlayGame()
    {
        StoredInformation.OnSave();
        PlayGameSelected = true;
    }
    public void MMOptions()
    {
        MMSelected = false;
        OptionsSelected = true;
    }
    public void MMQuit()
    {
        StoredInformation.OnSave();
        Application.Quit();
    }
    public void OptionsBack()
    {
        OptionsBackActive = true;
    }
    public void OptionsControls()
    {
        OptionsControlsActive = true;
    }
    public void ControlsBack()
    {
        OptionsControlsInactive = true;
    }
    public void PlayTutorial()
    {
        StoredInformation.OnSave();
        PlayTutorialSelected = true;
    }
}
