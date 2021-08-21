using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject shotPrefab;
    public GameObject currentShot;

    public int playerTeam;
    public int stock;
    public int maxStock;
    public float throwPower;

    public float shotPower;
    public float maxShotPower;
    public float shotGainRate;
    public float shotCooldown;
    private float currentShotCooldown;
    public AudioClip aimSound;
    public AudioClip shotSound;
    private AudioSource sounds;

    public Reflector reflector;

    public GameObject aimIndicator;

    public EffectManager effectManager;
    private PlayerController playerController;
    public PlayerHealthDisplay playerHealthDisplay;

    public GameObject DeathPrefab;
    public Color teamColor;
    

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        sounds = GetComponent<AudioSource>();
        stock = maxStock;
        effectManager = GetComponent<EffectManager>();
        effectManager.StopChargingEffect();
        currentShotCooldown = shotCooldown;
    }
    private void Update()
    {
        currentShotCooldown = currentShotCooldown > 0 ? currentShotCooldown -= Time.deltaTime : currentShotCooldown;
    }

    public void ActivateShield()
    {
        if (!reflector.shieldBroken)
        {
            reflector.shieldActive = true;
        }
    }

    public void DeactivateShield()
    {
        reflector.shieldActive = false;
    }

    public void FireShot(Vector3 angle)
    {
        if (currentShot != null)
        {
            sounds.PlayOneShot(shotSound);
            Shot shot = currentShot.GetComponent<Shot>();
            currentShot = null;
            var dir = transform.position - aimIndicator.GetComponent<AimIndicator>().indicator.transform.position;
            shot.GetComponent<Rigidbody>().velocity = Vector2.zero;
            shot.GetComponent<Rigidbody>().AddForce(-dir * throwPower, ForceMode.Impulse);
            shot.Shoot(angle, playerTeam);
        }
    }

    public void StartAiming()
    { 
        if(currentShot == null && currentShotCooldown <= 0)
        {
            sounds.PlayOneShot(aimSound);
            currentShot = Instantiate(shotPrefab);
            Shot shot = currentShot.GetComponent<Shot>();
            shot.InitiateShot(
                0.4f,
                100,
                effectManager.teamColour);
            currentShotCooldown = shotCooldown;
        }
        else if (currentShot != null)
        {
            FireShot(playerController.aimAngle);
        }
    }

    public void StopCharging()
    {
        if(effectManager.ce_index == 0)
        {
            shotPower = 0;
            effectManager.chargePower = 0;
        }
    }

    public void IncrementShotPower()
    {
        shotPower = Mathf.Clamp(shotPower + shotGainRate * Time.deltaTime, 0, maxShotPower);
        effectManager.UpdateChargingEffect(shotPower / maxShotPower * 100);
    }

    public void ResetShotPower()
    {
        shotPower = 0;
        effectManager.StopChargingEffect();
    }

    public void HideShotEffect()
    {
        effectManager.StopChargingEffect();
    }

    public int GetShotPowerIndex()
    {
        return effectManager.ce_index;
    }

    public void SetAimInidicatorRotation(Quaternion rot)
    {
        aimIndicator.transform.rotation = rot;
    }

    public void SetAimIndicatorPosition()
    {
        if(currentShot != null)
        {
            currentShot.transform.position = aimIndicator.GetComponent<AimIndicator>().indicator.transform.position;
        }
    }

    public void HitShield(float amount)
    {
        reflector.currentShield -= amount;
    }

    public void Die()
    {
        stock--;
        playerHealthDisplay.ManageStockImages(stock);

        if (stock > 0)
        {
            var deathobj = Instantiate(DeathPrefab, transform.position, Quaternion.identity).GetComponent<DeathObject>();
            deathobj.Initialize(teamColor);
            GameManager.gm.playerDeath(gameObject);
        }
        else
        {
            GameManager.gm.WinGame(this);
        }
       
    }

    public void ResetPlayer()
    {
        stock = maxStock;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerHealthDisplay.ManageStockImages(stock);
    }

}
