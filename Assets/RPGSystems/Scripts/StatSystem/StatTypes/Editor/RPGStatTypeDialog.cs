using UnityEngine;
using UnityEditor;
using System.Collections;

namespace RPGSystems.StatSystem.Editor {
    public class RPGStatTypeDialog : EditorWindow {
        const string windowTitle = "Stat Types";

        public delegate void SelectEvent(RPGStatTypeAsset asset);
        public SelectEvent OnAssetSelect;

        private Vector2 scroll;

        static public void Display(SelectEvent del) {
            var wnd = GetWindow<RPGStatTypeDialog>(true, windowTitle, true);
            wnd.OnAssetSelect = del;
            wnd.Show();
        }

        public void OnGUI() {
            scroll = GUILayout.BeginScrollView(scroll);
            for (int i = 0; i < RPGStatTypeDatabase.GetAssetCount(); i++) {
                var asset = RPGStatTypeDatabase.GetAt(i);
                if (asset != null) {
                    if (GUILayout.Button(asset.Name, EditorStyles.toolbarButton)) {
                        if (OnAssetSelect != null) {
                            OnAssetSelect(asset);
                        }
                        this.Close();
                    }
                }
            }
            GUILayout.EndScrollView();
        }
    }
}
