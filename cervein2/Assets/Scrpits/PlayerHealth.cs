using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using JetBrains.Annotations;

public class PlayerHealth : MonoBehaviour
{
    //floats
    public float HBBG;
    public float MinHBBG;
    public float HBBGDecreaseMargine;
    public float playerHealth;
    public float playerMaxHealth;
    public float HealthTimer;
    public float MaxHealthTimer;
    public float ShakeTimer;
    public float IconTimer;
    //booleans
    public bool isDead = false;
    public bool lostHealth = false;
    public bool IsHit = false;
    public bool PlayShake = false;
    //images and UI
    public Image HealthBarImage;
    public Image HealthBarBackgroundImage;
    public TextMeshProUGUI HealthDisplay;
    //Animators
    public Animator HealthBarCanvasGroup;
    public Animator IconAnimator;
    //scripts
    public Death Death;
    public DeerPathfinding deerPathfinding;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set the player's health to the max
        playerHealth = playerMaxHealth;
        //Set the player's cooldown to the max
        HealthTimer = MaxHealthTimer;
        UpdateTextDisplay();
        MinHBBG = playerMaxHealth / playerMaxHealth;
        HBBG = playerMaxHealth / playerMaxHealth;
        HealthBarCanvasGroup.Play("HealthBarFreeze");
        IconAnimator.Play("Non-Existent");
    }

    // Update is called once per frame
    void Update()
    {
        //decrease health timer indefinitely.
        HealthTimer -= Time.deltaTime;
        if(isDead)
        {

        }
        HealthBarBackgroundImage.fillAmount = HBBG;
        if(lostHealth)
        {
            StartCoroutine(DecreaseValueCoroutine());
        }
        if(IsHit)
        {
            if(PlayShake)
            {
                ShakeTimer += Time.deltaTime;
                HealthBarCanvasGroup.Play("DamageShakeBar");
            }
            if(ShakeTimer >= 0.1666666f)
            {
                HealthBarCanvasGroup.Play("HealthBarFreeze");
                ShakeTimer = 0;
                PlayShake = false;
            }
            IconTimer += Time.deltaTime;
            IconAnimator.Play("TakeOneDamage");
            if (IconTimer >= 1f)
            {
                IconAnimator.Play("Non-Existent");
                IconTimer = 0;
                IsHit = false;
            }
        }
    }
    //OnTriggerStay is called once per frame when making collision with another object, and stops as soon as the objects are no longer colliding. Triggers allow for non-physical collisions
    private void OnTriggerStay(Collider Collision)
    {
        if(Collision.gameObject.CompareTag("Enemy") && HealthTimer <= 0)
        {
            if(deerPathfinding.IsDeerUpset)
            {
                //Take Damage (no shit)
                playerHealth--;
                //update HealthBar accordingly
                HealthBarImage.fillAmount = playerHealth / playerMaxHealth;
                UpdateTextDisplay();
                MinHBBG = playerHealth / playerMaxHealth;
                lostHealth = true;
                IsHit = true;
                PlayShake = true;
                //Die if your health is depleted (also no shit, Sherlock)
                if(playerHealth <= 0 && !isDead)
                {
                    isDead = true;
                    playerHealth = 0;
                    Death.OnDeath();
                }
                HealthTimer = MaxHealthTimer;
            }

        }
    }
    public IEnumerator DecreaseValueCoroutine()
    {
        while(HBBG > MinHBBG)
        {
            HBBG -= HBBGDecreaseMargine;
            if(HBBG < MinHBBG)
            {
                HBBG = MinHBBG;
                lostHealth = false;
            }
            yield return null;
        }
    }
    public void UpdateTextDisplay()
    {
        //update health display accordingly
        HealthDisplay.text = $"Health: {playerHealth}/{playerMaxHealth}".ToString();
    }
}
//Fuck you, Watson