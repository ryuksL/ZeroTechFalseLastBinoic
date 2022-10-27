using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace LingGame;

public class Comp_LingSpawnItem : ThingComp
{
    public CompProperties_LingSpawnItem Props => (CompProperties_LingSpawnItem)props;

    public override IEnumerable<Gizmo> CompGetGizmosExtra()
    {
        foreach (var item in base.CompGetGizmosExtra())
        {
            yield return item;
        }

        yield return new Command_Action
        {
            defaultLabel = "Open",
            defaultDesc = "Open This Box",
            defaultIconColor = Color.grey,
            action = delegate
            {
                foreach (var item2 in Props.list)
                {
                    GenSpawn.Spawn(ThingMaker.MakeThing(item2), parent.InteractionCell, parent.Map);
                }

                parent.Destroy();
            }
        };
    }
}