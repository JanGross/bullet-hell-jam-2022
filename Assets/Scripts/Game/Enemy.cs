using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int baseScore;
    public PatternTypes[] patterns;
    public int CurrentPattern;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack()
    {
        //Spawn pattern
    }

    public void Consumed()
    {

    }


    private void OnPatternFinished()
    {
        //Increment pattern
    }

}
