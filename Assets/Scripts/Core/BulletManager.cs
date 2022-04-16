using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PatternTypes
{
    DEFAULT
}

[System.Serializable]
public class PatternMap
{
    public PatternTypes patternType;
    public Pattern pattern;
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

    public Pattern SpawnPattern(PatternTypes pattern)
    {
        return null;
    }
}
