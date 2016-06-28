using UnityEngine;
using System;
using System.Collections;

namespace RPGSystems.StatSystem {
    /// <summary>
    /// RPGStat that inherits from RPGAttribute and implement IStatCurrentValueChange
    /// </summary>
    public class RPGVital : RPGAttribute, IStatCurrentValueChange {
        /// <summary>
        /// Used by the StatCurrentValue Property
        /// </summary>
        private int _statCurrentValue;

        /// <summary>
        /// Event called when the StatCurrentValue changes
        /// </summary>
        public event EventHandler OnCurrentValueChange;

        /// <summary>
        /// The current value of the stat. Restricted between the values 0 
        /// and StatValue. When set will trigger the OnCurrentValueChange event.
        /// </summary>
        public int StatCurrentValue {
            get {
                if (_statCurrentValue > StatValue) {
                    _statCurrentValue = StatValue;
                } else if (_statCurrentValue < 0) {
                    _statCurrentValue = 0;
                }
                return _statCurrentValue;
            }
            set {
                if (_statCurrentValue != value) {
                    _statCurrentValue = value;
                    TriggerCurrentValueChange();
                }
            }
        }

        /// <summary>
        /// Basic Constructor
        /// </summary>
        public RPGVital() {
            _statCurrentValue = 0;
        }

        /// <summary>
        /// Sets the StatCurrentValue to StatValue
        /// </summary>
        public void SetCurrentValueToMax() {
            StatCurrentValue = StatValue;
        }

        /// <summary>
        /// Triggers the OnCurrentValueChange Event
        /// </summary>
        private void TriggerCurrentValueChange() {
            if (OnCurrentValueChange != null) {
                OnCurrentValueChange(this, null);
            }
        }
    }
}
