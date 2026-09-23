using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public static float MainTimer;
    public static float MainMaxTimer;
    public float MaxTimer;
    public static float NewMaxTimer;
    public float ResetMaxTimer;
    public Image WristWatch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //When the Instance starts, the Main Timer starts at its maximum
        MainMaxTimer = MaxTimer;
        MainTimer = MainMaxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //Time depletes indefinitely
        MainTimer -= Time.deltaTime;
        //Adjusting WristWatch FillAmount to match the amount of time left.
        WristWatch.fillAmount = MainTimer / MainMaxTimer;
    }
}
