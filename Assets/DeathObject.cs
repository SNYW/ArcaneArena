
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    public float dissolveRate;
    private SpriteRenderer sr;

    void Update()
    {
            sr.material.SetFloat(
                "DissolveAmount",
                 Mathf.Clamp(sr.material.GetFloat("DissolveAmount") - Time.deltaTime * dissolveRate / 2, 0, 1)
                 );

            if (sr.material.GetFloat("DissolveAmount") <= 0)
            {
                Destroy(gameObject);
            }
        
    }

    public void Initialize(Color col)
    {
        sr = GetComponent<SpriteRenderer>();
        sr.material = Instantiate(sr.material);
        sr.color = col;
    }
}
