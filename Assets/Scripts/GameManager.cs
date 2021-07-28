using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public bool playing;

    public Player playerOne;
    public Player playerTwo;

    public float respawnTime;
    public GameObject[] respawnPoints;

    void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }

        playing = false;
    }

    public void StartGame()
    {
        playing = true;
    }

    public void StopGame()
    {
        playing = false;
    }

    public void playerDeath(GameObject player)
    {
        player.SetActive(false);
        var spawner = respawnPoints[Random.Range(0, respawnPoints.Length - 1)].GetComponent<RespawnPoint>();
        spawner.TriggerRespawner(player, respawnTime);
    }
}
