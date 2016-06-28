using UnityEngine;
using System.Collections;
using System;

namespace RPGSystems.Utility.Database {
    public class BaseDatabase : AbstractDatabase<BaseDatabaseAsset> {
        protected override void OnAddObject(BaseDatabaseAsset obj) {
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }

        protected override void OnRemoveObject(BaseDatabaseAsset obj) {
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }
    }
}
