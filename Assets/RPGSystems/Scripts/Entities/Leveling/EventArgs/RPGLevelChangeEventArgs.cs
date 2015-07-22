using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Event Args used for displaying changes in a entity's level
/// </summary>
public class RPGLevelChangeEventArgs : EventArgs {
    /// <summary>
    /// Gets the New Level changed to
    /// </summary>
    public int NewLevel { get; private set; }

    /// <summary>
    /// Gets the Old Level changed from
    /// </summary>
    public int OldLevel { get; private set; }

    /// <summary>
    /// Basic Contructor takes the old and new levels
    /// </summary>
    public RPGLevelChangeEventArgs(int newLevel, int oldLevel) {
        NewLevel = newLevel;
        OldLevel = oldLevel;
    }
}
