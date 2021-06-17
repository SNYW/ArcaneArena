using UnityEngine;
using UnityEngine.VFX;

public class EffectManager : MonoBehaviour
{
    public VisualEffect chargingEffect;

    public float ce_maxInnerRadius;
    public float ce_maxAmount;
    public Gradient teamColour;
    public float[] ce_powerBreakPoints;
    public int ce_index;
    public float chargePower;

    private void Start()
    {
        StopChargingEffect();    
    }

    public void UpdateChargingEffect(float chargePercentage)
    {
        chargingEffect.SetGradient("Team Colour", teamColour);
        chargingEffect.enabled = true;
        chargePower = ce_maxAmount / 100 * chargePercentage;

        if(ce_index == 0)
        {
            chargingEffect.SetFloat("Amount", ce_powerBreakPoints[ce_index]);
            chargingEffect.SetFloat("InnerSphereRadius", 0);
            chargingEffect.SetFloat("OuterAmount", 1);
        }
        if(chargePower > ce_powerBreakPoints[ce_index])
        {
            if(ce_index < ce_powerBreakPoints.Length-1) ce_index++;
            chargingEffect.SetFloat("Amount", ce_powerBreakPoints[ce_index]);
            chargingEffect.SetFloat("InnerSphereRadius", (ce_maxInnerRadius/ce_powerBreakPoints.Length*ce_index));
        }
        if(chargingEffect.GetFloat("Amount") > ce_powerBreakPoints[ce_powerBreakPoints.Length-2])
        {
            chargingEffect.SetFloat("OuterAmount", 0);
        }


    }

    public void StopChargingEffect()
    {
        chargingEffect.enabled = false;
    }

}
