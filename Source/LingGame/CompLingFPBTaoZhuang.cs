using System.Linq;
using Verse;

namespace LingGame
{
    public class CompLingFPBTaoZhuang : HediffComp
    {
        private bool NeedFix = true;

        public ComppLingFPBTaoZhuang Porps => (ComppLingFPBTaoZhuang)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            if (!NeedFix)
            {
                return;
            }

            if (aHasHediff(Porps.hediffDef, out var hediff))
            {
                parent.pawn.health.RemoveHediff(hediff);
            }

            var hediff2 = HediffMaker.MakeHediff(Porps.hediffDef, parent.pawn);
            var count = parent.pawn.health.hediffSet.hediffs.Where(x =>
                    x.def.defName.Contains(Def.defName.Substring(0, 13)) &&
                    x.def.HasComp(typeof(CompLingFPBTaoZhuang)))
                .ToList().Count;
            hediff2.Severity = (0.04f * count) + 0.001f;
            parent.pawn.health.AddHediff(hediff2);
            NeedFix = false;
        }

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Values.Look(ref NeedFix, "NeedFix");
        }

        public bool aHasHediff(HediffDef def, out Hediff hediff, bool mustBeVisible = false)
        {
            foreach (var hediff1 in parent.pawn.health.hediffSet.hediffs)
            {
                if (hediff1.def != def || mustBeVisible && !hediff1.Visible)
                {
                    continue;
                }

                hediff = hediff1;
                return true;
            }

            hediff = null;
            return false;
        }
    }
}