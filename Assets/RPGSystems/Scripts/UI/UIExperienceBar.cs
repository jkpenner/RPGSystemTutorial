using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIExperienceBar : MonoBehaviour {
    public RPGEntity entity;
    public RectTransform expBarArea;
    public RectTransform expBarFill;
    public Text expBarValues;

	void Awake () {
        entity.EntityLevel.OnEntityExpGain += OnExpGain;
	}

    void OnExpGain(object sender, RPGExpGainEventArgs args) {
        // Find the precentage of the current levels required experience the entity has
        float expPercent = Mathf.Clamp((float)entity.EntityLevel.ExpCurrent / (float)entity.EntityLevel.ExpRequired, 0f, 1f);

        // Get the new right offset value
        float newRightOffset = -expBarArea.rect.width + expBarArea.rect.width * expPercent;

        // Set the ExpBarFill's new right offset
        expBarFill.offsetMax = new Vector2(newRightOffset, expBarFill.offsetMax.y);

        // Update the exp bar value text with correct values
        expBarValues.text = string.Format("{0} / {1} (Level {2})", 
            entity.EntityLevel.ExpCurrent, 
            entity.EntityLevel.ExpRequired, 
            entity.EntityLevel.Level);
    }
}
