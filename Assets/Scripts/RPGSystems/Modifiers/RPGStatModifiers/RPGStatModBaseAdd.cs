using UnityEngine;
using System.Collections;

/// <summary>
/// Modifier that adds the value to the stat value
/// </summary>
public class RPGStatModBaseAdd : RPGStatModifier {
    public override int Order { get { return 2; } }

    public override int ApplyModifier(int statValue, float modValue) {
        return (int)(modValue);
    }

    public RPGStatModBaseAdd(float value) : base (value) { }
    public RPGStatModBaseAdd(float value, bool stacks) : base(value, stacks) { }
}