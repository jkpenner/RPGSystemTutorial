using UnityEngine;
using System.Collections;

public abstract class RPGStatModifier {
    private float _value;
    private bool _stacks;

    public abstract int Order { get; }

    public float Value {
        get { return _value; }
        set { _value = value; }
    }

    public bool Stacks {
        get { return _stacks; }
        set { _stacks = value; }
    }

    public RPGStatModifier() {
        _value = 0;
        _stacks = true;
    }

    public RPGStatModifier(float value) {
        _value = value;
        _stacks = true;
    }

    public RPGStatModifier(float value, bool stacks) {
        _value = value;
        _stacks = stacks;
    }

    public abstract int ApplyModifier(int statValue, float modValue);
}
