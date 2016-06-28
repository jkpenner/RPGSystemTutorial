using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace RPGSystems.Utility.Database {
    public abstract class AbstractDatabase<T> : ScriptableObject where T : IDatabaseAsset {
        [SerializeField]
        private List<T> _objects;

        protected List<T> Objects {
            get {
                if (_objects == null) {
                    _objects = new List<T>();
                }
                return _objects;
            }
        }

        protected abstract void OnAddObject(T obj);
        protected abstract void OnRemoveObject(T obj);

        public void Add(T obj) {
            Objects.Add(obj);
            OnAddObject(obj);
        }

        public void Remove(T obj) {
            Objects.Remove(obj);
            OnRemoveObject(obj);
        }

        public void RemoveAt(int index) {
            var obj = GetAtIndex(index);
            Objects.RemoveAt(index);
            OnRemoveObject(obj);
        }

        public void Replace(int index, T obj) {
            var oldObj = Objects[index];
            Objects[index] = obj;
            OnRemoveObject(oldObj);
            OnAddObject(obj);
        }

        public int Count {
            get { return Objects.Count; }
        }

        public T GetAtIndex(int index) {
            if (Count > 0) {
                if (index >= 0 && index < this.Count) {
                    return Objects[index];
                }
            }
            return default(T);
        }

        public T GetById(int id) {
            for (int i = 0; i < Count; i++) {
                var asset = GetAtIndex(i);
                if (asset.Id == id) {
                    return asset;
                }
            }
            return default(T);
        }

        public int GetFirstAvalibleId() {
            if (Count <= 0) {
                return 1;
            } else {
                int targetId = 1;
                bool foundUsableId = false;
                while (!foundUsableId) {
                    foundUsableId = true;
                    for (int i = 0; i < Count; i++) {
                        if (GetAtIndex(i).Id == targetId) {
                            foundUsableId = false;
                            targetId++;
                            break;
                        }
                    }
                }
                return targetId;
            }
        }

        public int GetNextId() {
            int maxId = 0;
            for (int i = 0; i < Count; i++) {
                var asset = GetAtIndex(i);
                if (asset.Id > maxId) {
                    maxId = asset.Id;
                }
            }
            return maxId + 1;
        }

        public bool ContainsDuplicateIds() {
            for (int i = 0; i < Count - 1; i++) {
                var asset1 = GetAtIndex(i);
                for (int j = i + 1; j < Count; j++) {
                    var asset2 = GetAtIndex(j);
                    if (asset1.Id == asset2.Id) {
                        return true;
                    }
                }
            }
            return false;
        }

        static public U GetDatabase<U>(string path, string name) where U : ScriptableObject {
#if UNITY_EDITOR
            string fullPath = @"Assets/" + path + name;
            U database = AssetDatabase.LoadAssetAtPath<U>(fullPath);

            if (database == null) {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/" + path);
                database = ScriptableObject.CreateInstance<U>();
                AssetDatabase.CreateAsset(database, fullPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            return database;
#else
        U database = Resources.Load<U>(path.Replace("Resources/", "") + name.Replace(".asset", ""));
        if (database == null) {
            Debug.LogWarning("No Database found of type " + typeof(U).Name);
            return null;
        } else {
            return database;
        }
#endif
        }
    }
}