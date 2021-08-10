using UnityEngine;
using UnityEngine.VFX;

public class Reflector : MonoBehaviour
{
    private Collider2D col;
    private VisualEffect effect;
    public int teamIndex;
    private SpriteRenderer sprite;
    private Material spriteMaterial;

    public float shieldResetTime;
    public float currentResetTime;

    public float shieldMaximum;
    public float currentShield;
    public float shieldDrainFactor;
    public float shieldGainFactor;
    private float shieldPercentage;

    private float maxChargeAmount;
    private float currentChargeAmount;
    public float chargedShieldAlpha;
    public float dissolveRate;


    public bool charged;
    public bool shieldActive;
    public bool shieldBroken;
    void Start()
    {
        currentShield = shieldMaximum;
        maxChargeAmount = 6.3f;
        shieldBroken = false;
        currentChargeAmount = maxChargeAmount;
        col = GetComponent<Collider2D>();
        col.enabled = false;
        effect = GetComponent<VisualEffect>();
        shieldActive = false;
        sprite = GetComponent<SpriteRenderer>();
        sprite.material = Instantiate(sprite.material);
        spriteMaterial = sprite.material;
        spriteMaterial.SetColor("_Color", sprite.color);
        sprite.material.SetFloat("DissolveAmount", 0);
    }

    private void Update()
    {
        shieldPercentage = currentShield / shieldMaximum * 100;
        col.enabled = shieldActive;
        if (!shieldBroken)
        {
            ManageChargeAmount(100-shieldPercentage);
            ManageShield();
        }
        else
        {
            currentResetTime = GetShieldCooldown();
            if (currentResetTime == shieldResetTime)
            {
                shieldBroken = false;
                currentShield = shieldMaximum;
            }
            else
            {
                shieldActive = false;
                ManageBrokenShield(currentResetTime / shieldResetTime * 100);
            }
        }
    }

    private float GetShieldCooldown()
    {
        return Mathf.Clamp(currentResetTime + Time.deltaTime, 0, shieldResetTime); 
    }

    public void UpdateChargeAmount(float chargeAmount)
    {
        currentChargeAmount = chargeAmount;
    }

    private void ManageShield()
    {
        if (!shieldActive)
        {
            currentShield = Mathf.Clamp(currentShield + Time.deltaTime * shieldGainFactor, 0, shieldMaximum);
            spriteMaterial.SetFloat(
                 "DissolveAmount",
                 Mathf.Clamp(spriteMaterial.GetFloat("DissolveAmount") - Time.deltaTime * dissolveRate / 2, 0, 1)
                 );
        }
        else
        {
            if (currentShield <= 0)
            {
                shieldBroken = true;
                currentResetTime = 0;
            }
            else
            {
               // currentShield = Mathf.Clamp(currentShield - Time.deltaTime * shieldDrainFactor, 0, shieldMaximum);
                spriteMaterial.SetFloat(
                    "DissolveAmount",
                    Mathf.Clamp(spriteMaterial.GetFloat("DissolveAmount") + Time.deltaTime * dissolveRate, 0, 1)
                    );
            }
        }
    }

    private void ManageBrokenShield(float percentage)
    {
        currentChargeAmount = maxChargeAmount / 100 * percentage;
        effect.SetFloat("Arc", currentChargeAmount);
        spriteMaterial.SetFloat("DissolveAmount", 0);

    }

    public void ManageChargeAmount(float percentCharged)
    {
        float percentage = 100 - percentCharged;
        currentChargeAmount = maxChargeAmount/100 * percentage;
        effect.SetFloat("Arc", currentChargeAmount);
    }

    

}
