using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGStatModifiable : RPGStat, IStatModifiable, IStatValueChange {
    private List<RPGStatModifier> _statMods;
    private int _statModValue;

    public event System.EventHandler OnValueChange;

    public override int StatValue {
        get { return base.StatValue + StatModifierValue;}
    }

    public int StatModifierValue {
        get { return _statModValue; }
    }

    public RPGStatModifiable() {
        _statModValue = 0;
        _statMods = new List<RPGStatModifier>();
    }

    protected void TriggerValueChange() {
        if (OnValueChange != null) {
            OnValueChange(this, null);
        }
    }

    public void AddModifier(RPGStatModifier mod) {
        _statMods.Add(mod);
    }

    public void ClearModifiers() {
        _statMods.Clear();
    }

    public void UpdateModifiers() {
        _statModValue = 0;

        float statModBaseValueAdd = 0;
        float statModBaseValuePercent = 0;
        float statModTotalValueAdd = 0;
        float statModTotalValuePercent = 0;

        foreach (RPGStatModifier mod in _statMods) {
            switch (mod.Type) {
                case RPGStatModifier.Types.BaseValueAdd:
                    statModBaseValueAdd += mod.Value;
                    break;
                case RPGStatModifier.Types.BaseValuePercent: 
                    statModBaseValuePercent += mod.Value;
                    break;
                case RPGStatModifier.Types.TotalValueAdd: 
                    statModTotalValueAdd += mod.Value;
                    break;
                case RPGStatModifier.Types.TotalValuePercent: 
                    statModTotalValuePercent += mod.Value;
                    break;
            }
        }

        _statModValue = (int)((StatBaseValue * statModBaseValuePercent) + statModBaseValueAdd);
        _statModValue += (int)((StatValue * statModTotalValuePercent) + statModTotalValueAdd);

        TriggerValueChange();
    }
}
