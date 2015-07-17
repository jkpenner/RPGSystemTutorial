using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// The base class for all RPGStatModifiers
/// </summary>
[System.Serializable]
public abstract class RPGStatModifier {
    /// <summary>
    /// Variable used for the Value property
    /// </summary>
    [SerializeField]
    private float _value = 0f;

    /// <summary>
    /// Variable used for the Stacks property
    /// </summary>
    [SerializeField]
    private bool _stacks = true;

    /// <summary>
    /// Event that triggers when the Stat Modifier's Value property changes
    /// </summary>
    public event EventHandler OnValueChange;

    /// <summary>
    /// The order in which the modifier is applied to the stat
    /// </summary>
    public abstract int Order { get; }

    /// <summary>
    /// The value of the modifier that is combined with other
    /// modifiers of the same stat then is passed to ApplyModifier
    /// method to determine the final modifier value to apply to the stat
    /// 
    /// Triggers the OnValueChange event
    /// </summary>
    public float Value {
        get {
            return _value;
        }
        set {
            if (_value != value) {
                _value = value;
                if (OnValueChange != null) {
                    OnValueChange(this, null);
                }
            }
        }
    }

    /// <summary>
    /// Does the modifier's value stat with other modifiers of the 
    /// same type. If value is false, the value of the single modifier will be used
    /// if the sum of stacking modifiers is not greater then the not statcking mod.
    /// </summary>
    public bool Stacks {
        get { return _stacks; }
        set { _stacks = value; }
    }

    /// <summary>
    /// Default Constructer
    /// </summary>
    public RPGStatModifier() {
        Value = 0;
        Stacks = true;
    }

    /// <summary>
    /// Constructs a Stat Modifier with the given value and stack set to true
    /// </summary>
    public RPGStatModifier(float value) {
        Value = value;
        Stacks = true;
    }

    /// <summary>
    /// Constructs a Stat Modifier with the given value and stack value
    /// </summary>
    public RPGStatModifier(float value, bool stacks) {
        Value = value;
        Stacks = stacks;
    }

    /// <summary>
    /// Calculates the amount to apply to the stat based off the 
    /// sum of all the stat modifier's value and the current value of
    /// the stat.
    /// </summary>
    public abstract int ApplyModifier(int statValue, float modValue);
}
