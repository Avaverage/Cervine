using UnityEngine;
using System;
using System.IO;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
