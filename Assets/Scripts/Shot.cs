using UnityEngine;
using UnityEngine.VFX;

public class Shot : MonoBehaviour
{
    private VisualEffect shotEffect;
    private CircleCollider2D col;
    public int teamIndex;
    public GameObject explosionPrefab;
    public float explosionRadius;
    private Gradient teamColour;

    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
        shotEffect = GetComponent<VisualEffect>();

        col.enabled = false;
    }

    public void InitiateShot(float isr, float amount, Gradient teamColour, int expRadius)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && player.playerTeam != teamIndex)
        {
            if (player.reflector.shieldActive)
            {
                player.HitShield(explosionRadius*20);
            }
            else
            {
                player.Die();
            }
            
        }
        if(explosionRadius > 0)
        {
            var exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            exp.GetComponent<ShotExplosion>().InitExplosion(explosionRadius, teamColour, teamIndex);
        }

        Destroy(gameObject);
    }
}
