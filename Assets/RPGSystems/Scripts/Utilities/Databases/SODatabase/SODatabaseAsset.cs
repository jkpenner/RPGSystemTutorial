using UnityEngine;
using System.Collections;

namespace RPGSystems.Utility.Database {
    public class SODatabaseAsset : ScriptableObject, IDatabaseAsset {
        [SerializeField]
        private int _id;

        [SerializeField]
        private string _name;

        public int Id {
            get { return _id; }
            set { _id = value; }
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public SODatabaseAsset() {
            this.Id = -1;
            this.Name = string.Empty;
        }

        public SODatabaseAsset(int id) {
            this.Id = id;
            this.Name = string.Empty;
        }

        public SODatabaseAsset(int id, string name) {
            this.Id = id;
            this.Name = name;
        }
    }
}
