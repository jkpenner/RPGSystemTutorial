using UnityEngine;
using System.Collections;

/// <summary>
/// The base class for all other Stats.
/// </summary>
public class RPGStat {
    /// <summary>
    /// Used by the StatName Property
    /// </summary>
    private string _statName;

    /// <summary>
    /// Used by the StatBase Value Property
    /// </summary>
    private int _statBaseValue;

    /// <summary>
    /// The Name of the Stat
    /// </summary>
    public string StatName {
        get { return _statName; }
        set { _statName = value; }
    }

    /// <summary>
    /// The Total Value of the stat
    /// </summary>
    public virtual int StatValue {
        get { return StatBaseValue; }
    }

    /// <summary>
    /// The Base Value of the stat
    /// </summary>
    public virtual int StatBaseValue {
        get { return _statBaseValue; }
        set { _statBaseValue = value; }
    }

    /// <summary>
    /// Basic Constructor
    /// </summary>
    public RPGStat() {
        this.StatName = string.Empty;
        this.StatBaseValue = 0;
    }
}
