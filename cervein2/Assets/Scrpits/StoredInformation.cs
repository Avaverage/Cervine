using UnityEngine;
using System;
using System.IO;
using TMPro;
using System.Threading;
using UnityEngine.SceneManagement;
[System.Serializable]
public class StoredInformation : MonoBehaviour
{
    [SerializeField] public float MusicVolume;
    [SerializeField] public float SFXVolume;
    [SerializeField] public float HighScore;
    public static float MusicVolumeStatic;
    public static float SFXVolumeStatic;
    public static float HighScoreStatic;
    public static float EndgameScore;
    private string saveFilePath;
    string json;
    //UI stuff
    public string DataRecollectionMessage;
    public TextMeshProUGUI MainText;
    public bool DataFound = false;
    public float timer;
    public bool timerActive = true;
    public float timer2 = 3;
    public float timer3 = 0;
    public CanvasGroup FadeOut;
    public AudioSource PlayerAudio;
    public AudioClip NoSave;
    public AudioClip YesSave;
    public string levelToLoad;
    void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.json");
    }
    public void OnSave()
    {
        //GatherInformation
        StoredInformation data = new StoredInformation();
        //volume of different types of audio (adjustable)
        data.MusicVolume = MusicVolumeStatic;
        data.SFXVolume = SFXVolumeStatic;
        //Score counting
        data.HighScore = HighScoreStatic;
        json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game Saved To: " + saveFilePath);
    }
    public void OnLoad()
    {
        if(File.Exists(saveFilePath))
        {
            json = File.ReadAllText(saveFilePath);
            StoredInformation data = JsonUtility.FromJson<StoredInformation>(json);
            Debug.Log($"Loaded Music Volume: {data.MusicVolume}, SFX Volume: {data.SFXVolume}, HighScore: {data.HighScore}");
            //translate json information to static variables
                //Volume
            MusicVolumeStatic = data.MusicVolume;
            SFXVolumeStatic = data.SFXVolume;
                //HighScore
            HighScoreStatic = data.HighScore;
            DataFound = true;
        }
        else
        {
            Debug.Log("Save file was not found.");
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnLoad();
        DataRecollectionMessage = "Checking Data . . .";
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timer += Time.deltaTime;
            FadeOut.alpha = timer2 / 3;
        }
        else
        {
            timer3 += Time.deltaTime;
            FadeOut.alpha = timer3 / 3;
        }
        timer2 -= Time.deltaTime;
        if (timer2 <= -9)
        {
            SceneManager.LoadScene(levelToLoad);
        }
        if (timer >= 6)
        {
            if(DataFound)
            {
                DataRecollectionMessage = "Save File Found";
                UpdateText();
                PlayerAudio.PlayOneShot(YesSave);
            }
            else
            {
                DataRecollectionMessage = "No Save File Found";
                UpdateText();
                PlayerAudio.PlayOneShot(NoSave);
            }
            timerActive = false;
            timer = 0;
        }
    }
    void UpdateText()
    {
        MainText.text = $"{DataRecollectionMessage}".ToString();
    }
}
