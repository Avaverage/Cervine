using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    //floats
    public float playerHealth;
    public float playerMaxHealth;
    public float HealthTimer;
    public float MaxHealthTimer;
    //booleans
    public bool isDead = false;
    //images and UI
    public Image HealthBarImage;
    public TextMeshProUGUI HealthDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set the player's health to the max
        playerHealth = playerMaxHealth;
        //Set the player's cooldown to the max
        HealthTimer = MaxHealthTimer;
        UpdateTextDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        //decrease health timer indefinitely.
        HealthTimer -= Time.deltaTime;
        if(isDead)
        {

        }
    }
    //OnTriggerStay is called once per frame when making collision with another object, and stops as soon as the objects are no longer colliding. Triggers allow for non-physical collisions
    private void OnTriggerStay(Collider Collision)
    {
        if(Collision.gameObject.CompareTag("Enemy") && HealthTimer <= 0)
        {
            //Take Damage (no shit)
            playerHealth--;
            //update HealthBar accordingly
            HealthBarImage.fillAmount = playerHealth / playerMaxHealth;
            UpdateTextDisplay();
            //Die if your health is depleted (also no shit, Sherlock)
            if(playerHealth <= 0)
            {
                isDead = true;
                playerHealth = 0;
            }
            HealthTimer = MaxHealthTimer;
        }
    }
    public void UpdateTextDisplay()
    {
        //update health display accordingly
        HealthDisplay.text = $"{playerHealth}/{playerMaxHealth}".ToString();
    }
}
//Fuck you, Watson