using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RPGSystems.StatSystem {
    /// <summary>
    /// The base class used to define a collection of RPGStats.
    /// Also used to apply and remove RPGStatModifiers from individual
    /// RPGStats.
    /// </summary>
    public class RPGStatCollection : MonoBehaviour {
        private Dictionary<RPGStatType, RPGStat> _statDict;

        /// <summary>
        /// Dictionary containing all stats held within the collection
        /// </summary>
        public Dictionary<RPGStatType, RPGStat> StatDict {
            get {
                if (_statDict == null) {
                    _statDict = new Dictionary<RPGStatType, RPGStat>();
                }
                return _statDict;
            }
        }

        /// <summary>
        /// Initializes the RPGStats class
        /// </summary>
        private void Awake() {
            ConfigureStats();
        }

        /// <summary>
        /// Overridable method used to create and setup the stats contained within
        /// the RPGStats class: StatLinkers, Stat Default Values, Etc.
        /// </summary>
        protected virtual void ConfigureStats() { }

        /// <summary>
        /// Checks if there is a RPGStat with the given type and id
        /// </summary>
        public bool ContainStat(RPGStatType statType) {
            return StatDict.ContainsKey(statType);
        }

        /// <summary>
        /// Gets the RPGStat with the given RPGStatTyp and ID
        /// </summary>
        public RPGStat GetStat(RPGStatType statType) {
            if (ContainStat(statType)) {
                return StatDict[statType];
            }
            return null;
        }

        /// <summary>
        /// Gets the RPGStat with the given RPGStatType and ID as type T
        /// </summary>
        public T GetStat<T>(RPGStatType type) where T : RPGStat {
            return GetStat(type) as T;
        }

        /// <summary>
        /// Creates a new instance of the stat ands adds it to the StatDict
        /// </summary>
        protected T CreateStat<T>(RPGStatType statType) where T : RPGStat {
            T stat = System.Activator.CreateInstance<T>();
            StatDict.Add(statType, stat);
            return stat;
        }

        /// <summary>
        /// Creates or Gets a RPGStat of type T. Used within the setup method during initialization.
        /// </summary>
        protected T CreateOrGetStat<T>(RPGStatType statType) where T : RPGStat {
            T stat = GetStat<T>(statType);
            if (stat == null) {
                stat = CreateStat<T>(statType);
            }
            return stat;
        }


        /// <summary>
        /// Adds a Stat Modifier to the Target stat.
        /// </summary>
        public void AddStatModifier(RPGStatType target, RPGStatModifier mod) {
            AddStatModifier(target, mod, false);
        }

        /// <summary>
        /// Adds a Stat Modifier to the Target stat and then updates the stat's value.
        /// </summary>
        public void AddStatModifier(RPGStatType target, RPGStatModifier mod, bool update) {
            if (ContainStat(target)) {
                var modStat = GetStat(target) as IStatModifiable;
                if (modStat != null) {
                    modStat.AddModifier(mod);
                    if (update == true) {
                        modStat.UpdateModifiers();
                    }
                } else {
                    Debug.Log("[RPGStats] Trying to add Stat Modifier to non modifiable stat \"" + target.ToString() + "\"");
                }
            } else {
                Debug.Log("[RPGStats] Trying to add Stat Modifier to \"" + target.ToString() + "\", but RPGStats does not contain that stat");
            }
        }

        /// <summary>
        /// Removes a Stat Modifier to the Target stat.
        /// </summary>
        public void RemoveStatModifier(RPGStatType target, RPGStatModifier mod) {
            RemoveStatModifier(target, mod, false);
        }

        /// <summary>
        /// Removes a Stat Modifier to the Target stat and then updates the stat's value.
        /// </summary>
        public void RemoveStatModifier(RPGStatType target, RPGStatModifier mod, bool update) {
            if (ContainStat(target)) {
                var modStat = GetStat(target) as IStatModifiable;
                if (modStat != null) {
                    modStat.RemoveModifier(mod);
                    if (update == true) {
                        modStat.UpdateModifiers();
                    }
                } else {
                    Debug.Log("[RPGStats] Trying to remove Stat Modifier from non modifiable stat \"" + target.ToString() + "\"");
                }
            } else {
                Debug.Log("[RPGStats] Trying to remove Stat Modifier from \"" + target.ToString() + "\", but RPGStatCollection does not contain that stat");
            }
        }

        /// <summary>
        /// Clears all stat modifiers from all stats in the collection.
        /// </summary>
        public void ClearStatModifiers() {
            ClearStatModifiers(false);
        }

        /// <summary>
        /// Clears all stat modifiers from all stats in the collection then updates all the stat's values.
        /// </summary>
        /// <param name="update"></param>
        public void ClearStatModifiers(bool update) {
            foreach (var key in StatDict.Keys) {
                ClearStatModifier(key, update);
            }
        }

        /// <summary>
        /// Clears all stat modifiers from the target stat.
        /// </summary>
        public void ClearStatModifier(RPGStatType target) {
            ClearStatModifier(target, false);
        }

        /// <summary>
        /// Clears all stat modifiers from the target stat then updates the stat's value.
        /// </summary>
        public void ClearStatModifier(RPGStatType target, bool update) {
            if (ContainStat(target)) {
                var modStat = GetStat(target) as IStatModifiable;
                if (modStat != null) {
                    modStat.ClearModifiers();
                    if (update == true) {
                        modStat.UpdateModifiers();
                    }
                } else {
                    Debug.Log("[RPGStats] Trying to clear Stat Modifiers from non modifiable stat \"" + target.ToString() + "\"");
                }
            } else {
                Debug.Log("[RPGStats] Trying to clear Stat Modifiers from \"" + target.ToString() + "\", but RPGStatCollection does not contain that stat");
            }
        }

        /// <summary>
        /// Updates all stat modifier's values
        /// </summary>
        public void UpdateStatModifiers() {
            foreach (var key in StatDict.Keys) {
                UpdateStatModifer(key);
            }
        }

        /// <summary>
        /// Updates the target stat's modifier value
        /// </summary>
        public void UpdateStatModifer(RPGStatType target) {
            if (ContainStat(target)) {
                var modStat = GetStat(target) as IStatModifiable;
                if (modStat != null) {
                    modStat.UpdateModifiers();
                } else {
                    Debug.Log("[RPGStats] Trying to Update Stat Modifiers for a non modifiable stat \"" + target.ToString() + "\"");
                }
            } else {
                Debug.Log("[RPGStats] Trying to Update Stat Modifiers for \"" + target.ToString() + "\", but RPGStatCollection does not contain that stat");
            }
        }

        /// <summary>
        /// Scales all stats in the collection to the same target level
        /// </summary>
        public void ScaleStatCollection(int level) {
            foreach (var key in StatDict.Keys) {
                ScaleStat(key, level);
            }
        }

        /// <summary>
        /// Scales the target stat in the collection to the target level
        /// </summary>
        public void ScaleStat(RPGStatType target, int level) {
            if (ContainStat(target)) {
                var stat = GetStat(target) as IStatScalable;
                if (stat != null) {
                    stat.ScaleStat(level);
                } else {
                    Debug.Log("[RPGStats] Trying to Scale Stat with a non scalable stat \"" + target.ToString() + "\"");
                }
            } else {
                Debug.Log("[RPGStats] Trying to Scale Stat for \"" + target.ToString() + "\", but RPGStatCollection does not contain that stat");
            }
        }
    }
}
