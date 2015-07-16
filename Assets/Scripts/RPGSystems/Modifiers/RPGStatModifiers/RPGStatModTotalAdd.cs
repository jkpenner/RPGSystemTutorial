using UnityEngine;
using System.Collections;

/// <summary>
/// Modifier that adds the value to the stat value
/// </summary>
public class RPGStatModTotalAdd : RPGStatModifier {
    public override int Order { get { return 4; } }

    public override int ApplyModifier(int statValue, float modValue) {
        return (int)(modValue);
    }

    public RPGStatModTotalAdd(float value) : base (value) { }
    public RPGStatModTotalAdd(float value, bool stacks) : base(value, stacks) { }
}
