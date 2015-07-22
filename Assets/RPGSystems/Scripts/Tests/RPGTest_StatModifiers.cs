using UnityEngine;
using System.Collections;

public class RPGTest_StatModifiers : MonoBehaviour {
    private RPGStatModifiable stat;

	void Start () {
        bool passed = true;
        stat = new RPGStatModifiable();
        
        // Set the Starting base value
        int statTargetValue = 100;
        stat.StatBaseValue = statTargetValue;
        
        // Create instance of the modifiers with all values set to 0
        RPGStatModifier[] mods = new RPGStatModifier[] {
            new RPGStatModBaseAdd(0),
            new RPGStatModBasePercent(0),
            new RPGStatModTotalAdd(0),
            new RPGStatModTotalPercent(0)
        };

        // Add lisener event to each modifier and add mod to stat
        foreach (var mod in mods) {
            //Debug.Log("Stat Listening to Mod: " + mod.GetType().ToString());
            mod.OnValueChange += OnValueChange;
            stat.AddModifier(mod);
        }

        // Change the Base Add Mod Value
        int baseAddValue = 100;
        statTargetValue += baseAddValue;
        mods[0].Value = baseAddValue;

        // Check if the target value is the same as the stat's value
        passed = passed && stat.StatValue == statTargetValue;
        Debug.Log(string.Format("Check[{0}]: Stat Value {1}, Target Value {2}", passed, stat.StatValue, statTargetValue));

        // Change the Base Percent Mod Value
        float basePercentValue = 0.5f;
        statTargetValue += (int)(statTargetValue * basePercentValue);
        mods[1].Value = basePercentValue;

        // Check if the target value is the same as the stat's value
        passed = passed && stat.StatValue == statTargetValue;
        Debug.Log(string.Format("Check[{0}]: Stat Value {1}, Target Value {2}", passed, stat.StatValue, statTargetValue));

        // Change the Base Add Mod Value
        int totalAddValue = 100;
        statTargetValue += totalAddValue;
        mods[2].Value = totalAddValue;

        // Check if the target value is the same as the stat's value
        passed = passed && stat.StatValue == statTargetValue;
        Debug.Log(string.Format("Check[{0}]: Stat Value {1}, Target Value {2}", passed, stat.StatValue, statTargetValue));

        // Change the Base Percent Mod Value
        float totalPercentValue = 0.5f;
        statTargetValue += (int)(statTargetValue * totalPercentValue);
        mods[3].Value = totalPercentValue;

        // Check if the target value is the same as the stat's value
        passed = passed && stat.StatValue == statTargetValue;
        Debug.Log(string.Format("Check[{0}]: Stat Value {1}, Target Value {2}", passed, stat.StatValue, statTargetValue));

        Debug.Log(string.Format("Stat Modifier Test: {0}", passed ? "Passed" : "Failed"));
	}

    private void OnValueChange(object mod, System.EventArgs args) {
        //Debug.Log("On Value Changed Called For Modifier: " + mod.GetType().ToString());
        stat.UpdateModifiers();
    }
}
