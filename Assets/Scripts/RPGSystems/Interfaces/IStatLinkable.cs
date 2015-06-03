using UnityEngine;
using System.Collections;

public interface IStatLinkable {
    int StatLinkerValue { get; }

    void AddLinker(RPGStatLinker linker);
    void ClearLinkers();
    void UpdateLinkers();
}