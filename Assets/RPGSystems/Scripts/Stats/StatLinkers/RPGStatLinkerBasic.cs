using UnityEngine;
using System.Collections;

/// <summary>
/// Basic implementation of a RPGStatLinker. Returns a percentage 
/// of the Linked Stat
/// </summary>
public class RPGStatLinkerBasic : RPGStatLinker {
    /// <summary>
    /// The Ratio of the linked stat to use
    /// </summary>
    private float _ratio;

    /// <summary>
    /// returns the ratio of the linked stat as the linker's value
    /// </summary>
    public override int Value {
        get { return (int)(LinkedStat.StatValue * _ratio); }
    }

    /// <summary>
    /// Constructor that takes the linked stat and the ratio to use
    /// </summary>
    public RPGStatLinkerBasic(RPGStat stat, float ratio)
        : base(stat) {
        _ratio = ratio;
    }
}
