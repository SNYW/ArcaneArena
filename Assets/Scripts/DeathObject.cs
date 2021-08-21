
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    public float dissolveRate;
    private SpriteRenderer sr;
    private void Awake()
    {
        PlaySoundRandomPitch();
    }
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
        sr.material.SetColor("_Color", col);
    }

    private void PlaySoundRandomPitch()
    {
        var source = GetComponent<AudioSource>();
        source.pitch = Random.Range(0.8f, 1.2f);
        source.Play();
    }
}
