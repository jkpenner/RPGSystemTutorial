using UnityEngine;
using System.Collections;

namespace RPGSystems.Utility.Database {
    public interface IDatabaseAsset {
        int Id { get; set; }
        string Name { get; set; }
    }
}
