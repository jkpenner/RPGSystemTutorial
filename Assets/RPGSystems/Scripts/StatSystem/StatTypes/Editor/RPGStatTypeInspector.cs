using UnityEngine;
using UnityEditor;
using RPGSystems.StatSystem;
using System.Collections;

namespace RPGSystems.StatSystem.Editor {
    [CustomEditor(typeof(RPGStatTypeDatabase))]
    public class RPGStatTypeInspector : UnityEditor.Editor {
        private string output = "";

        public override void OnInspectorGUI() {
            GUILayout.Label("Database that stores all RPGStatTypes.");

            if (GUILayout.Button("Open Editor Window")) {
                RPGStatTypeWindow.ShowWindow();
            }
        }
    }
}
