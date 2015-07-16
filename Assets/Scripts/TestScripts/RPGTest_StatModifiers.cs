using UnityEngine;
using System.Collections;

public class RPGTest_StatModifiers : MonoBehaviour {
	void Start () {
        int statTargetValue = 100;

        RPGStatModifiable stat = new RPGStatModifiable();
        stat.StatBaseValue = statTargetValue;

        statTargetValue += 100;
        stat.AddModifier(new RPGStatModBaseAdd(100));
        stat.UpdateModifiers();

        Debug.Log(string.Format("Stat's value is {0}, target value is {1}", stat.StatValue, statTargetValue));

        statTargetValue += (int)(statTargetValue * 0.5f);
        stat.AddModifier(new RPGStatModBasePercent(0.5f));
        stat.UpdateModifiers();

        Debug.Log(string.Format("Stat's value is {0}, target value is {1}", stat.StatValue, statTargetValue));

        statTargetValue += 100;
        stat.AddModifier(new RPGStatModTotalAdd(100));
        stat.UpdateModifiers();

        Debug.Log(string.Format("Stat's value is {0}, target value is {1}", stat.StatValue, statTargetValue));

        statTargetValue += (int)(statTargetValue * 0.5f);
        stat.AddModifier(new RPGStatModTotalPercent(0.5f));
        stat.UpdateModifiers();
	}
}
