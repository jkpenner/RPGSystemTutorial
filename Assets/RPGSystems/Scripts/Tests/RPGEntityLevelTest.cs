using UnityEngine;
using System.Collections;

public class RPGEntityLevelTest : MonoBehaviour {
    public RPGEntityLevel entityLevel;

	void Update () {
        entityLevel.ModifyExp(100);
	}
}
