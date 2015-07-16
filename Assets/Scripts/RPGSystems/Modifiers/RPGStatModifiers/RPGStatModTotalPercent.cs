using UnityEngine;
using System.Collections;

/// <summary>
/// Modifier that takes a percentage of the stat's value
/// </summary>
public class RPGStatModTotalPercent : RPGStatModifier {
    public override int Order {
        get { return 3; }
    }

    public override int ApplyModifier(int statValue, float modValue) {
        return (int)(statValue * modValue);
    }

    public RPGStatModTotalPercent(float value) : base (value) { }
    public RPGStatModTotalPercent(float value, bool stacks) : base(value, stacks) { }
}
