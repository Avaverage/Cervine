using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //integers
    public int playerHealth;
    public int playerMaxHealth;
    //booleans
    public bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider Collision)
    {
        if(Collision.gameObject.CompareTag("Enemy"))
        {
            //Take Damage (no shit)
            playerHealth--;
            //Die if your health is depleted
            if(playerHealth <= 0)
            {
                isDead = true;
            }
        }
    }
}
