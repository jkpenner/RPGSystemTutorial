using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGStatCollection {
    private Dictionary<RPGStatType, RPGStat> _statDict;

    public RPGStatCollection() {
        _statDict = new Dictionary<RPGStatType, RPGStat>();
        ConfigureStats();
    }

    protected virtual void ConfigureStats() {

    }

    public bool Contains(RPGStatType statType) {
        return _statDict.ContainsKey(statType);
    }

    public RPGStat GetStat(RPGStatType statType) {
        if (Contains(statType)) {
            return _statDict[statType];
        }
        return null;
    }

    public T GetStat<T>(RPGStatType type) where T : RPGStat {
        return GetStat(type) as T;
    }

    protected T CreateStat<T>(RPGStatType statType) where T : RPGStat {
        T stat = System.Activator.CreateInstance<T>();
        _statDict.Add(statType, stat);
        return stat;
    }

    protected T CreateOrGetStat<T>(RPGStatType statType) where T : RPGStat {
        T stat = GetStat<T>(statType);
        if (stat == null) {
            stat = CreateStat<T>(statType);
        }
        return stat;
    }
}
