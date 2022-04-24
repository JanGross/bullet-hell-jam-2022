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

    public List<Wave> waves;
    public GameObject enemyHolder;
    private Wave currentWave;


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
        
    }

    public void StartWave()
    {
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

                Instantiate(currentWave.enemies[i].gameObject, spawnPos, Quaternion.identity, enemyHolder.transform);
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
            StartWave();

        }
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
        //get active scene and reload it 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void OpenScoreboard()
    {
        SceneManager.LoadScene("Scoreboard");
    }
}
