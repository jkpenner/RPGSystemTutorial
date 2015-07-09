using UnityEngine;
using System;
using System.Collections;

public abstract class RPGStatLinker : IStatValueChange {
    private RPGStat _stat;

    public event EventHandler OnValueChange;

    public RPGStatLinker(RPGStat stat) {
        _stat = stat;

        IStatValueChange iValueChange = _stat as IStatValueChange;
        if (iValueChange != null) {
            iValueChange.OnValueChange += OnLinkedStatValueChange;
        }
    }

    public RPGStat Stat {
        get { return _stat; }
    }

    public abstract int Value { get; }

    private void OnLinkedStatValueChange(object stat, EventArgs args) {
        if (OnValueChange != null) {
            OnValueChange(this, null);
        }
    }
}
