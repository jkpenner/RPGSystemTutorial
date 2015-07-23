using UnityEngine;
using System.Collections;

public class RPGEntityLevelTest : MonoBehaviour {
    public RPGEntity entity;

    void Awake() {
        entity.EntityLevel.OnEntityLevelUp += OnEntityLevelUp;
    }

	void Update () {
        entity.EntityLevel.ModifyExp(100);
        //entity.EntityLevel.IncreaseCurrentLevel();
	}

    void OnEntityLevelUp(object sender, RPGLevelChangeEventArgs args) {
        Debug.Log(string.Format("Level up: oldLevel {0}, newLevel {1}", args.OldLevel, args.NewLevel));
    }
}
