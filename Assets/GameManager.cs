using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public Player playerOne;
    public Player playerTwo;

    public float respawnTime;
    public GameObject[] respawnPoints;

    void Start()
    {
        if(gm == null)
        {
            gm = this;
        }
    }

    void Update()
    {
        
    }

    public void playerDeath(GameObject player)
    {
        player.SetActive(false);
        var spawner = respawnPoints[Random.Range(0, respawnPoints.Length - 1)].GetComponent<RespawnPoint>();
        spawner.TriggerRespawner(player, respawnTime);
    }
}
