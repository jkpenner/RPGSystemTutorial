using UnityEngine;
using System.Collections;
using System;

namespace RPGSystems.StatSystem {
    /// <summary>
    /// Used to indicate when the stat's value changes
    /// </summary>
    public interface IStatValueChange {
        event EventHandler OnValueChange;
    }
}
