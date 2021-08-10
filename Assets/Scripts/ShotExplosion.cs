using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ShotExplosion : MonoBehaviour
{

    private VisualEffect effect;
    private SphereCollider col;
    public LayerMask hitMask;
    public int teamIndex;

    private bool hitFlag;

    private void Update()
    {
        if (!hitFlag)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, col.radius, hitMask);
            if (hits.Length > 0)
            {
                foreach(Collider col in hits)
                {
                    Player player = col.gameObject.transform.parent.transform.parent.GetComponent<Player>();
                    if (player != null && player.playerTeam != teamIndex)
                    {
                        if (player.reflector.shieldActive)
                        {
                            player.HitShield(this.col.radius * 20);
                        }
                        else
                        {
                            player.Die();
                        }
                        hitFlag = true;
                    }
                }
            }
        }
    }

    public void InitExplosion(float radius, Gradient teamColour, int teamIndex)
    {
        effect = GetComponent<VisualEffect>();
        col = GetComponent<SphereCollider>();
        col.radius = radius;
        effect.SetFloat("Radius", radius);
        effect.SetGradient("TeamColour", teamColour);
        this.teamIndex = teamIndex;
        Destroy(gameObject, 0.3f);
        hitFlag = false;
    }
}
