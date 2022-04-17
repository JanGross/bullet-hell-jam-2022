using UnityEngine;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyConsumed()
    {

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
}
