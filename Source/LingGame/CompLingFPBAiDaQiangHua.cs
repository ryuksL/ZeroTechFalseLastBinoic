using RimWorld;
using Verse;

namespace LingGame;

public class CompLingFPBAiDaQiangHua : HediffComp
{
    private int AiDannt;
    private int ttis;

    public override void CompExposeData()
    {
        Scribe_Values.Look(ref AiDannt, "AiDannt");
    }

    public override void CompPostTick(ref float severityAdjustment)
    {
        base.CompPostTick(ref severityAdjustment);
        ttis++;
        if (ttis < 6000)
        {
            return;
        }

        if (Pawn.records.GetAsInt(RecordDefOf.DamageTaken) > AiDannt)
        {
            parent.Severity += 0.01f * (Pawn.records.GetAsInt(RecordDefOf.DamageTaken) - AiDannt);
        }

        AiDannt = Pawn.records.GetAsInt(RecordDefOf.DamageTaken);
        ttis = 0;
    }
}