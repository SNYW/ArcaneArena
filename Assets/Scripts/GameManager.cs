using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public bool playing;

    public Player playerOne;
    public Player playerTwo;

    public float respawnTime;
    public GameObject[] respawnPoints;

    public Player winningPlayer;
    public GameObject winScreen;

    private Vector3 p1StartPosition;
    private Vector3 p2StartPosition;

    void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }

        p1StartPosition = playerOne.transform.position;
        p2StartPosition = playerTwo.transform.position;

        winScreen.SetActive(false);
        winningPlayer = null;
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
        var spawner = respawnPoints[Random.Range(0, respawnPoints.Length)].GetComponent<RespawnPoint>();
        while (!spawner.CanSpawn())
        {
            spawner = respawnPoints[Random.Range(0, respawnPoints.Length)].GetComponent<RespawnPoint>();
        }
        
        spawner.TriggerRespawner(player, respawnTime);
    }

    public void ResetGame()
    {

        playerOne.gameObject.SetActive(true);
        playerTwo.gameObject.SetActive(true);

        playerOne.transform.position = p1StartPosition;
        playerTwo.transform.position = p2StartPosition;

        winningPlayer = null;
        winScreen.SetActive(false);

        playerOne.ResetPlayer();
        playerTwo.ResetPlayer();

        GetComponent<TimeLineManager>().introTimeline.Play();
    }

    public void WinGame(Player p)
    {
        if(p.playerTeam == 1)
        {
            winningPlayer = playerTwo;
            playerOne.gameObject.SetActive(false);
        }
        else
        {
            winningPlayer = playerOne;
            playerTwo.gameObject.SetActive(false);
        }
        winScreen.SetActive(true);
        playing = false;
    }
}