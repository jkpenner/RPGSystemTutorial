using UnityEngine;
using System.Collections;
using UnityEditor;

static public class RPGItemMenuUtility {
    [MenuItem("Assets/Create/RPG/Item")]
    static public void CreateItem() {
        ScriptableObjectUtility.CreateAsset<RPGItem>();
    }
}