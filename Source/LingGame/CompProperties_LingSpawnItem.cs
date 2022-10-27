using System.Collections.Generic;
using Verse;

namespace LingGame;

public class CompProperties_LingSpawnItem : CompProperties
{
    public List<ThingDef> list;

    public CompProperties_LingSpawnItem()
    {
        compClass = typeof(Comp_LingSpawnItem);
    }
}