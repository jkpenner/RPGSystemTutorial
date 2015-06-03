using UnityEngine;
using System.Collections;

public abstract class RPGStatLinker {
    private RPGStat _stat;

    public RPGStatLinker(RPGStat stat) {
        _stat = stat;
    }

    public RPGStat Stat {
        get { return _stat; }
    }

    public abstract int Value { get; }
}
