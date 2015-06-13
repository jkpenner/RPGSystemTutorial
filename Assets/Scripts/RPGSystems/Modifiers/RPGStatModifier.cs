using UnityEngine;
using System.Collections;

public abstract class RPGStatModifier {
    private int _order;
    private float _value;

    public int Order {
        get { return _order; }
        set { _order = value; }
    }

    public float Value {
        get { return _value; }
        set { _value = value; }
    }

    public RPGStatModifier() {
        _order = -1;
        _value = 0;
    }

    public RPGStatModifier(int order, float value) {
        _order = order;
        _value = value;
    }

    public abstract int ApplyModifier(int statValue, float modValue);
}
