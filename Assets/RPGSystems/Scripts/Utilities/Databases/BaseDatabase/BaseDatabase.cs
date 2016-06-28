using UnityEngine;
using System.Collections;
using System;

namespace RPGSystems.Utility.Database {
    public class BaseDatabase<T> : AbstractDatabase<T> where T : BaseDatabaseAsset {
        protected override void OnAddObject(T obj) {
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }

        protected override void OnRemoveObject(T obj) {
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }
    }
}
