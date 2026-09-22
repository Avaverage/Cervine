using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public static float MainTimer;
    public static float MainMaxTimer;
    public static float NewMaxTimer;
    public Image WristWatch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
