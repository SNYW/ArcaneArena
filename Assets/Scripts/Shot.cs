using UnityEngine;
using UnityEngine.VFX;

public class Shot : MonoBehaviour
{
    private VisualEffect shotEffect;
    private SphereCollider col;
    public int teamIndex;
    public GameObject explosionPrefab;
    public float explosionRadius;
    private Gradient teamColour;
    private int bounces;

    private void Awake()
    {
        bounces = 2;
        col = GetComponent<SphereCollider>();
        shotEffect = GetComponent<VisualEffect>();

        col.enabled = false;
    }

    public void InitiateShot(float isr, float amount, Gradient teamColour)
    {
        shotEffect.SetFloat("InnerSphereRadius", isr);
        shotEffect.SetFloat("Amount", amount);
        shotEffect.SetGradient("Team Colour", teamColour);
        this.teamColour = teamColour;
        explosionRadius = 2;
        col.radius = isr;
        col.enabled = false;
    }

    public void Shoot(Vector3 angle, int teamIndex)
    {
        Invoke("EnableCollider", 0.05f);
        transform.up = angle;
        this.teamIndex = teamIndex;
    }

    private void EnableCollider()
    {
        col.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && player.playerTeam != teamIndex)
        {
            if (player.reflector.shieldActive)
            {
                player.HitShield(explosionRadius*20);
                teamIndex = player.playerTeam;
                InitiateShot(0.4f, 100, player.effectManager.teamColour);
                EnableCollider();
            }
            else
            {
                Explode();
            }

        }
        else
        {
            bounces--;
            if(bounces <= 0)
            {
                Explode();
            }
        }

    }

    private void Explode()
    {
        var exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        exp.GetComponent<ShotExplosion>().InitExplosion(explosionRadius, teamColour, teamIndex);
        Destroy(gameObject);
    }
}
