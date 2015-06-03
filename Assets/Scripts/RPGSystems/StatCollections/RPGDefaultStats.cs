using UnityEngine;
using System.Collections;

public class RPGDefaultStats : RPGStatCollection {
    protected override void ConfigureStats() {
        var stamina = CreateOrGetStat<RPGAttribute>(RPGStatType.Stamina);
        stamina.StatName = "Stamina";
        stamina.StatBaseValue = 10;

        var wisdom = CreateOrGetStat<RPGAttribute>(RPGStatType.Wisdom);
        wisdom.StatName = "Wisdom";
        wisdom.StatBaseValue = 5;

        var health = CreateOrGetStat<RPGAttribute>(RPGStatType.Health);
        health.StatName = "Health";
        health.StatBaseValue = 100;
        health.AddLinker(new RPGStatLinkerBasic(CreateOrGetStat<RPGAttribute>(RPGStatType.Stamina), 13f));
        health.UpdateLinkers();

        var mana = CreateOrGetStat<RPGAttribute>(RPGStatType.Mana);
        mana.StatName = "Mana";
        mana.StatBaseValue = 2000;
        mana.AddLinker(new RPGStatLinkerBasic(CreateOrGetStat<RPGAttribute>(RPGStatType.Wisdom), 68f));
        health.UpdateLinkers();
    }
}
