using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Used to indicate when the stat's value changes
/// </summary>
public interface IStatValueChange {
    event EventHandler OnValueChange;
}
