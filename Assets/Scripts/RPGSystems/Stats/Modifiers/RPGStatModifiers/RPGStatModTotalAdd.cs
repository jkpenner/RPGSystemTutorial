using UnityEngine;
using System.Collections;

/// <summary>
/// Modifier that adds the value to the stat value
/// </summary>
public class RPGStatModTotalAdd : RPGStatModifier {
    /// <summary>
    /// The order in which the modifier is applied to the stat
    /// </summary>
    public override int Order { get { return 4; } }

    /// <summary>
    /// Calculates the amount to apply to the stat based off the 
    /// sum of all the stat modifier's value and the current value of
    /// the stat.
    /// </summary>
    public override int ApplyModifier(int statValue, float modValue) {
        return (int)(modValue);
    }

    /// <summary>
    /// Constructor that sets the Value and sets Stacks to true
    /// </summary>
    public RPGStatModTotalAdd(float value) : base (value) { }

    /// <summary>
    /// Constructor that sets the Value and Stacks
    /// </summary>
    public RPGStatModTotalAdd(float value, bool stacks) : base(value, stacks) { }
}
