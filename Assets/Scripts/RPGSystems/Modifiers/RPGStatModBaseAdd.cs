using UnityEngine;
using System.Collections;

public class RPGStatModBaseAdd : RPGStatModifier {
    public override int Order { get { return 2; } }

    public override int ApplyModifier(int statValue, float modValue) {
        return (int)(statValue + modValue);
    }

    public RPGStatModBaseAdd(float value) : base (value) { }
    public RPGStatModBaseAdd(float value, bool stacks) : base(value, stacks) { }
}