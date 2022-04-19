using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int baseScore;
    public PatternTypes[] patterns;
    public int CurrentPattern = 0;
    public float scoreMultiplier = 0;

    public bool IsDead { get; private set; }

    private BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        Attack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Attack()
    {
         bulletManager.SpawnPattern(patterns[CurrentPattern], this);
    }

    public void Consumed()
    {
        gameObject.SetActive(false); // TODO: some sort of effect

        // once the enemy dies it should stop emitting bullets but keep any active bullets running
        IsDead = true;

        bulletManager.EnemyConsumed(scoreMultiplier);
    }

    public void OnPatternFinished()
    {
        if (gameObject.activeSelf)
        {
            CurrentPattern++;
            if (CurrentPattern >= patterns.Length)
            {
                //Destroy(gameObject);
            }
            Attack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            // okay.. player hit so we're being consumed
            Consumed();
        }
    }

}
