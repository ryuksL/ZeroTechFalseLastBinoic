using RimWorld;
using Verse;

namespace LingGame
{
    public class CompLingFPBShaRenQiangHua : HediffComp
    {
        private int killannt;
        private int ttis;

        public override void CompExposeData()
        {
            Scribe_Values.Look(ref killannt, "killannt");
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            ttis++;
            if (ttis < 6000)
            {
                return;
            }

            if (Pawn.records.GetAsInt(RecordDefOf.Kills) > killannt)
            {
                parent.Severity += 0.1f * (Pawn.records.GetAsInt(RecordDefOf.Kills) - killannt);
            }

            killannt = Pawn.records.GetAsInt(RecordDefOf.Kills);
            ttis = 0;
        }
    }
}