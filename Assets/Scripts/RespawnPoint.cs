using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private GameObject playerToRespawn;
    private float spawnTime;
    private bool spawned;

    private void Update()
    {
        spawned = spawnTime <= 0;
        if(playerToRespawn != null)
        {
            if (spawned)
            {
                playerToRespawn.transform.position = transform.position;
                playerToRespawn.SetActive(true);
                playerToRespawn = null;
            }
            else
            {
                spawnTime -= Time.deltaTime;
            }
        }
        
    }

    public void TriggerRespawner(GameObject player,float spawnTime)
    {
        this.spawnTime = spawnTime;
        spawned = false;
        playerToRespawn = player;
        
    }
}
