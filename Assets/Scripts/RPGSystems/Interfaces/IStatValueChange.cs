using UnityEngine;
using System.Collections;
using System;

public interface IStatValueChange {
    event EventHandler OnValueChange;
}
