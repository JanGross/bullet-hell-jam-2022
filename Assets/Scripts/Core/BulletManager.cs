using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PatternTypes
{
    DEFAULT,
    DOUBLE_SPINNING,
    QUADRUPLE_SPINNING,
}

[System.Serializable]
public class PatternMap
{
    public PatternTypes patternType;
    public GameObject pattern;
}
public class BulletManager : MonoBehaviour
{
    public PatternTypes patterns;
    public List<PatternMap> PatternMap = new List<PatternMap>();
    public Pattern[] activePatterns;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPattern(PatternTypes pattern, Enemy enemy)
    {
        GameObject patternObject = Instantiate(PatternMap.Find(x => x.patternType == pattern).pattern, enemy.transform.position, Quaternion.identity);
        Pattern patternScript = patternObject.GetComponent<Pattern>();
        patternScript.enemy = enemy;
    }
}
