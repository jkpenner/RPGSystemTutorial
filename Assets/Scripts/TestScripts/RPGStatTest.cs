using UnityEngine;
using System.Collections;
using System;



public class RPGStatTest : MonoBehaviour {
    private RPGStatCollection stats;

	void Start () {
        stats = new RPGDefaultStats();

        var statTypes = Enum.GetValues(typeof(RPGStatType));
        foreach (var statType in statTypes) {
            RPGStat stat = stats.GetStat((RPGStatType)statType);
            if (stat != null) {
                Debug.Log(string.Format("Stat {0}'s value is {1}",
                    stat.StatName, stat.StatValue));
            }
        }

        var health = stats.GetStat<RPGStatModifiable>(RPGStatType.Health);
        health.AddModifier(new RPGStatModifier(RPGStatType.Health, RPGStatModifier.Types.BaseValuePercent, 1.0f));      // 200
        health.AddModifier(new RPGStatModifier(RPGStatType.Health, RPGStatModifier.Types.BaseValueAdd, 50f));           // 250
        health.AddModifier(new RPGStatModifier(RPGStatType.Health, RPGStatModifier.Types.TotalValuePercent, 1.0f));     // 500
        health.UpdateModifiers();

        foreach (var statType in statTypes) {
            RPGStat stat = stats.GetStat((RPGStatType)statType);
            if (stat != null) {
                Debug.Log(string.Format("Stat {0}'s value is {1}",
                    stat.StatName, stat.StatValue));
            }
        }
	}

    void ForEachEnum<T>(Action<T> action) {
        if (action != null) {
            var statTypes = Enum.GetValues(typeof(T));
            foreach (var statType in statTypes) {
                action((T)statType);
            }
        }
    }

    void DisplayStatValues() {
        ForEachEnum<RPGStatType>((statType) => {
            RPGStat stat = stats.GetStat((RPGStatType)statType);
            if (stat != null) {
                Debug.Log(string.Format("Stat {0}'s value is {1}",
                    stat.StatName, stat.StatValue));
            }
        });
    }
}


