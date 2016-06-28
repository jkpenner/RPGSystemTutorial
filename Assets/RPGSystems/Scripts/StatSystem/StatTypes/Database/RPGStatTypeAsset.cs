using UnityEngine;
using System.Collections;
using RPGSystems.Utility.Database;

namespace RPGSystems.StatSystem {
    [System.Serializable]
    public class RPGStatTypeAsset : BaseDatabaseAsset {
        [SerializeField]
        private string _nameShort;

        [SerializeField]
        private string _description;

        [SerializeField]
        private Sprite _icon;

        public string NameShort {
            get { return _nameShort; }
            set { _nameShort = value; }
        }

        public string Description {
            get { return _description; }
            set { _description = value; }
        }

        public Sprite Icon {
            get { return _icon; }
            set { _icon = value; }
        }

        public RPGStatTypeAsset() : base () {
            this.NameShort = string.Empty;
            this.Description = string.Empty;
            this.Icon = null;
        }

        public RPGStatTypeAsset(int id) : base(id) {
            this.NameShort = string.Empty;
            this.Description = string.Empty;
            this.Icon = null;
        }

        public RPGStatTypeAsset(int id, string name) : base(id, name) {
            this.NameShort = string.Empty;
            this.Description = string.Empty;
            this.Icon = null;
        }

        public RPGStatTypeAsset(int id, string name, string nameShort, string description, Sprite icon) : base(id, name) {
            this.NameShort = nameShort;
            this.Description = description;
            this.Icon = icon;
        }
    }
}