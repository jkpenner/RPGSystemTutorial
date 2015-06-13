using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        // Sort the statModifiers by their orders
        _statMods.Sort((x, y) => x.Order.CompareTo(y.Order));
        
        var orderGroups = _statMods.GroupBy(mod => mod.Order);
        foreach(var group in orderGroups) {
            float sum = 0;
            foreach(var mod in group) {
                sum += mod.Value;
            }
            _statModValue += group.First().ApplyModifier(StatBaseValue + _statModValue, sum);
        }



        int orderValue = 0;
        float sum = 0, max = 0;
        foreach (var mod in _statMods) {
            if (mod.Order == orderValue) {
                if (mod.Type == RPGStatModifier.ModType.Max) {
                    max = Mathf.Max(mod.Value, max);
                } else if (mod.Type == RPGStatModifier.ModType.Sum) {
                    sum += mod.Value;
                }
            } else {
                if (sum != 0 || max != 0) {
                    _statModValue = 
                }
            }
        }

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
