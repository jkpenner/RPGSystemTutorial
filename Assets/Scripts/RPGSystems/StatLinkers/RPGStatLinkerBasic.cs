using UnityEngine;
using System.Collections;

public class RPGStatLinkerBasic : RPGStatLinker {
    private float _ratio;

    public override int Value {
        get { return (int)(Stat.StatValue * _ratio); }
    }

    public RPGStatLinkerBasic(RPGStat stat, float ratio) : base(stat) {
        _ratio = ratio;
    }
}
