using UnityEngine;
using System.Collections;

namespace RPGSystems.Utility.Database {
    public class SODatabase<T> : AbstractDatabase<T> where T : SODatabaseAsset {
        protected override void OnAddObject(T obj) {
#if UNITY_EDITOR
            obj.hideFlags = HideFlags.HideInHierarchy;
            UnityEditor.AssetDatabase.AddObjectToAsset(obj, this);
            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }

        protected override void OnRemoveObject(T obj) {
#if UNITY_EDITOR
            DestroyImmediate(obj, true);
            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }
    }
}