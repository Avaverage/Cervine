using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //integers
    public int playerHealth;
    public int playerMaxHealth;
    //floats
    public float HealthTimer;
    public float MaxHealthTimer;
    //booleans
    public bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set the player's health to the max
        playerHealth = playerMaxHealth;
        //Set the player's cooldown to the max
        HealthTimer = MaxHealthTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //decrease health timer indefinitely.
        HealthTimer -= Time.deltaTime;
    }
    //OnTriggerStay is called once per frame when making collision with another object, and stops as soon as the objects are no longer colliding. Triggers allow for non-physical collisions
    private void OnTriggerStay(Collider Collision)
    {
        if(Collision.gameObject.CompareTag("Enemy") && HealthTimer <= 0)
        {
            //Take Damage (no shit)
            playerHealth--;
            //Die if your health is depleted (also no shit, Sherlock)
            if(playerHealth <= 0)
            {
                isDead = true;
            }
            HealthTimer = MaxHealthTimer;
        }
    }
}
//Fuck you Watson