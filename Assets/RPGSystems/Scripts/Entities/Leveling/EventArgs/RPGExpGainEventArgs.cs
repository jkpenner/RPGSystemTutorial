using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Event Args displaying a gain in experience
/// </summary>
public class RPGExpGainEventArgs : EventArgs {
    /// <summary>
    /// The gain in experience, can be positive or negative.
    /// </summary>
    public int ExpGained { get; private set; }

    /// <summary>
    /// Basic Constructor takes the experienced gained
    /// </summary>
    public RPGExpGainEventArgs(int expGained) {
        ExpGained = expGained;
    }
}

