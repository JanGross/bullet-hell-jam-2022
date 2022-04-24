using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Wave
{
    public List<Enemy> enemies;
}

public class GameManager : MonoBehaviour
{
    [Header("Stats")]
    public int score;
    public int wave;
    public int enemiesConsumed;

    [Header("References")]
    public Settings settings;
    public UIManager userInterfaceManager;
    public MusicManager musicManager;
    public Player player;
    public GameObject[] pickups;

    [Header("Timing")]
    public float pickupDelay;
    public float scoreMultiplier;

    public int overallWave = 0;

    public List<Wave> waves;
    public GameObject enemyHolder;
    private Wave currentWave;

    private float SPAWN_DROP_TIME = 10;
    private float lastSpawnTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //dont destroy on load
        DontDestroyOnLoad(this.gameObject);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawnTime > SPAWN_DROP_TIME)
        {
            lastSpawnTime = Time.time;
            SpawnPickup();
        }
    }

    public void StartWave()
    {
        if (wave >= waves.Count)
        {
            wave = 0;
        }

        Wave current = waves[wave];
        if (current != null)
        {
            // remove old enemies
            foreach(Transform child in enemyHolder.transform)
            {
                Destroy(child.gameObject);
            }
            enemiesConsumed = 0;

            // spawn the enemies
            currentWave = current;

            for (int i = 0; i < currentWave.enemies.Count; i++)
            {
                // spawn enemies in random positions
                // TODO: do we really want to do this?
                float spawnZ = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).z, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).z);
                float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

                Vector3 spawnPos = new Vector3(spawnX, player.gameObject.transform.position.y, spawnZ);

                GameObject obj = Instantiate(currentWave.enemies[i].gameObject, spawnPos, Quaternion.identity, enemyHolder.transform);
                obj.SetActive(true);
            }
        }
    }

    public void EnemyConsumed(float multiplier = 0)
    {
        enemiesConsumed++;

        IncrementScore(10, multiplier);

        if (enemiesConsumed == currentWave.enemies.Count)
        {
            // wave over... start next wave
            wave++;
            overallWave++;
            StartWave();
        }
    }

    public void SpawnPickup()
    {
        GameObject pickup = pickups[Random.Range(0, pickups.Length)];

        float spawnZ = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).z, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).z);
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        GameObject ins = Instantiate(pickup);
        ins.transform.position = new Vector3(spawnX, player.transform.position.y, spawnZ);
    }

    public void PlayerDed()
    {

    }

    public void IncrementMultiplier(float val)
    {

    }

    public void IncrementScore(int val, float multiplier = 0)
    {
        float incMutliplier = (multiplier > 0) ? multiplier : scoreMultiplier;
        score += Mathf.FloorToInt(50 * incMutliplier); // TODO: how do we want this to work exactly?
    }

    public void RestartGame()
    {
        Destroy(gameObject);

        //get active scene and reload it 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void OpenScoreboard()
    {
        SceneManager.LoadScene("Scoreboard");
    }
}
