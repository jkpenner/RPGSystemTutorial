using UnityEngine;
using System.Collections;
using RPGSystems.Utility.Database;

namespace RPGSystems.StatSystem {
    public class RPGStatTypeDatabase : BaseDatabase<RPGStatTypeAsset> {
        const string DatabasePath = @"Resources/RPGSystems/Databases/";
        const string DatabaseName = @"StatTypeDatabase.asset";

        static private RPGStatTypeDatabase _instance = null;
        static public RPGStatTypeDatabase Instance {
            get {
                if (_instance == null) {
                    _instance = GetDatabase<RPGStatTypeDatabase>(DatabasePath, DatabaseName);
                }
                return _instance;
            }
        }

        static public RPGStatTypeAsset GetAt(int index) {
            return Instance.GetAtIndex(index);
        }

        static public RPGStatTypeAsset GetAsset(int id) {
            return Instance.GetById(id);
        }

        static public int GetAssetCount() {
            return Instance.Count;
        }
    }
}
