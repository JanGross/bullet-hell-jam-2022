using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyConsumed(float multiplier = 0)
    {
        enemiesConsumed++;

        float incMutliplier = (multiplier > 0) ? multiplier : scoreMultiplier;

        score += Mathf.FloorToInt(50 * incMutliplier); // TODO: how do we want this to work exactly?
    }

    public void PlayerDed()
    {

    }

    public void IncrementMultiplier(float val)
    {

    }

    public void IncrementScore(int val)
    {
        
    }

    public void RestartGame()
    {
        //get active scene and reload it 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
