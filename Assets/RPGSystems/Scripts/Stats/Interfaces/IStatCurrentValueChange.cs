using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Used to indicate when the stat's current value changes
/// </summary>
public interface IStatCurrentValueChange {
    event EventHandler OnCurrentValueChange;
}
