using UnityEngine;
using System.Collections;

public interface IStatModifiable {
    int StatModifierValue { get; }

    void AddModifier(RPGStatModifier mod);
    void RemoveModifier(RPGStatModifier mod);
    void ClearModifiers();
    void UpdateModifiers();
}
