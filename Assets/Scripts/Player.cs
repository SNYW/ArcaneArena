using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject shotPrefab;
    public GameObject currentShot;

    public int playerTeam;
    public int stock;
    public float throwPower;

    public float shotPower;
    public float maxShotPower;
    public float shotGainRate;

    public Reflector reflector;

    public GameObject aimIndicator;

    private EffectManager effectManager;

    public GameObject DeathPrefab;
    public Color teamColor;
    

    private void Awake()
    {
        stock = 5;
        effectManager = GetComponent<EffectManager>();
        effectManager.StopChargingEffect();
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
            Shot shot = currentShot.GetComponent<Shot>();
            currentShot = null;
            var dir = transform.position - aimIndicator.GetComponent<AimIndicator>().indicator.transform.position;
            shot.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            shot.GetComponent<Rigidbody2D>().AddForce(-dir * throwPower, ForceMode2D.Impulse);
            shot.Shoot(angle, playerTeam);
        }
        shotPower = 0;
        effectManager.ce_index = 0;
        effectManager.chargePower = 0;
        effectManager.UpdateChargingEffect(0);
        effectManager.StopChargingEffect();
    }

    public void StartAiming()
    { 
        if(currentShot == null)
        {
            currentShot = Instantiate(shotPrefab);
            Shot shot = currentShot.GetComponent<Shot>();
            shot.InitiateShot(
                effectManager.chargingEffect.GetFloat("InnerSphereRadius"),
                effectManager.chargingEffect.GetFloat("Amount"),
                effectManager.teamColour,
                effectManager.ce_index);
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
        currentShot.transform.position = aimIndicator.GetComponent<AimIndicator>().indicator.transform.position;
    }

    public void HitShield(float amount)
    {
        reflector.currentShield -= amount;
    }

    public void Die()
    {
        stock--;
        var deathobj = Instantiate(DeathPrefab, transform.position, Quaternion.identity).GetComponent<DeathObject>();
        deathobj.Initialize(teamColor);
        GameManager.gm.playerDeath(gameObject);
    }

}
