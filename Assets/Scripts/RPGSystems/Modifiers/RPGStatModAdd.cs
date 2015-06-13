using UnityEngine;
using System.Collections;

public class RPGStatModAdd : RPGStatModifier {
    public override int ApplyModifier(int statValue, float modValue) {
        return (int)(statValue + modValue);
    }
}
