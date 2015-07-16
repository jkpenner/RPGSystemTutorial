using UnityEngine;
using System.Collections;

/// <summary>
/// Allows the stat to use stat linkers
/// </summary>
public interface IStatLinkable {
    int StatLinkerValue { get; }

    void AddLinker(RPGStatLinker linker);
    void RemoveLinker(RPGStatLinker linker);
    void ClearLinkers();
    void UpdateLinkers();
}