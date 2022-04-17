using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int baseScore;
    public PatternTypes[] patterns;
    public int CurrentPattern = 0;
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

    }


    public void OnPatternFinished()
    {
        CurrentPattern++;
        if (CurrentPattern >= patterns.Length)
        {
            //Destroy(gameObject);
        }
        Attack();
    }

}
