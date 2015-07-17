using UnityEngine;
using System.Collections;

/// <summary>
/// Example Entity Level class the implements the GetExpRequiredForLevel method
/// </summary>
public class RPGDefaultLevel : RPGEntityLevel {
    public override int GetExpRequiredForLevel(int level) {
        return (int)(Mathf.Pow(level, 2f) * 100) + 100;
    }
}
