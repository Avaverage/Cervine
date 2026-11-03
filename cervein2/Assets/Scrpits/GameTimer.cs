using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float MainTimer;
    public float MainMaxTimer;
    public float MaxTimer;
    public float NewMaxTimer;
    public float ResetMaxTimer;
    public Image WristWatch;
    //outside scripts that are pretty important for the game's function
    public FeedingDeer feedingDeer;
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
        if(feedingDeer.IsGameplayLoopStarted)
        {
            //Time depletes indefinitely
            MainTimer -= Time.deltaTime;
            //Adjusting WristWatch FillAmount to match the amount of time left.
            if(WristWatch != null)
            {
                WristWatch.fillAmount = MainTimer / MaxTimer;
            }
        }

    }
    public void ResetTimer()
    {
        MainTimer = MaxTimer;
    }
}
