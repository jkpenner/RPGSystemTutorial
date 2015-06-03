using UnityEngine;
using System.Collections;

public class RPGStatModifier {
    public enum Types {
        None,
        BaseValuePercent,
        BaseValueAdd,
        TotalValuePercent,
        TotalValueAdd,
    }

    private Types _type;
    private float _value;
    private RPGStatType _statType;

    public Types Type {
        get { return _type; }
        set { _type = value; }
    }

    public float Value {
        get { return _value; }
        set { _value = value; }
    }

    public RPGStatType StatType {
        get { return _statType; }
        set { _statType = value; }
    }

    public RPGStatModifier() {
        _type = Types.None;
        _value = 0;
        _statType = RPGStatType.None;
    }

    public RPGStatModifier(RPGStatType targetStat, Types modType, float value) {
        _type = modType;
        _statType = targetStat;
        _value = value;
    }
}
