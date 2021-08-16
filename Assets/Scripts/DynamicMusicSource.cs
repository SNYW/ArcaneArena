using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMusicSource : MonoBehaviour
{
    [Range(0,100)]
    public float playChance;

    public AudioClip[] clips;

    public AudioSource player;

    void Awake()
    {
        player = GetComponent<AudioSource>();
    }

    private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    public void PlayRandomClip()
    {   if(Random.Range(0,100) <= playChance)
        {
            if (!player.isPlaying)
            {
                player.clip = GetRandomClip();
                player.Play();
            }
        }
    }
}
