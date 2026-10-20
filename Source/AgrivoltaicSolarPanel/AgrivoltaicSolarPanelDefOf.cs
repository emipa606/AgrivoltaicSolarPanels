using RimWorld;
using Verse;

namespace AgrivoltaicSolarPanel;

[DefOf]
public static class AgrivoltaicSolarPanelDefOf
{
    public static ThingDef AgrivoltaicSolarPanel;

    static AgrivoltaicSolarPanelDefOf()
    {
        DefOfHelper.EnsureInitializedInCtor(typeof(AgrivoltaicSolarPanelDefOf));
    }
}