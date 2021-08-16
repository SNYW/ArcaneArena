using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMusicSystem : MonoBehaviour
{
    public DynamicMusicSource baseMusicSource;
    public DynamicMusicSource[] musicSources;

    public int maxSources;

    private void Start()
    {
        maxSources = 1;
        baseMusicSource.PlayRandomClip();
    }

    private void Update()
    {
        if (!baseMusicSource.player.isPlaying)
        {
            var concurrentSources = 0;
            baseMusicSource.PlayRandomClip();
            foreach(DynamicMusicSource dms in musicSources)
            {
                if(concurrentSources<maxSources) dms.PlayRandomClip();
                if (dms.player.isPlaying) concurrentSources++;
            }

            maxSources++;
        }
    }
}
