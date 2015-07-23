using UnityEngine;
using System.Collections;

public class RPGEntity : MonoBehaviour {
    [SerializeField]
    private RPGEntityLevel _entityLevel;

    public RPGEntityLevel EntityLevel {
        get { return _entityLevel; }
        set { _entityLevel = value; }
    }
    
	void Awake () {
        if (EntityLevel == null) {
            EntityLevel = GetComponent<RPGEntityLevel>();
            if (EntityLevel == null) {
                Debug.LogWarning("No RPGEntityLevel assigned to RPGEntity");
            }
        }
	}
}
