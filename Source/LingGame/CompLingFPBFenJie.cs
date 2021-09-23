using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace LingGame
{
    public class CompLingFPBFenJie : ThingComp
    {
        public ComppLingFPBFenJie Props => (ComppLingFPBFenJie)props;

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            yield return new Command_Action
            {
                defaultLabel = "Disintegration".Translate(),
                defaultDesc = "FPBDisintegrationDesc".Translate(),
                icon = ContentFinder<Texture2D>.Get("LingUI/Disintegration"),
                action = delegate
                {
                    for (var i = 0; i < parent.stackCount; i++)
                    {
                        GenSpawn.Spawn(ThingMaker.MakeThing(Props.ThingDefs.RandomElement()), parent.InteractionCell,
                            parent.Map);
                        parent.Destroy();
                    }
                }
            };
        }
    }
}