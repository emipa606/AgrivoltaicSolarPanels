using Verse;

namespace AgrivoltaicSolarPanel
{
    public class PlaceWorker_NotNearAnotherTallBuilding : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
            Thing thingToIgnore = null, Thing thing = null)
        {
            var occupiedRect = GenAdj.OccupiedRect(loc, rot, new IntVec2(6, 6));
            foreach (var c in occupiedRect)
            {
                var list = map.thingGrid.ThingsListAt(c);
                foreach (var thing2 in list)
                {
                    if (thing2 == thingToIgnore)
                    {
                        continue;
                    }

                    var thingDef = thing2.def;
                    if (thing2.def.IsBlueprint || thing2.def.IsFrame)
                    {
                        if (thing2.def.entityDefToBuild is not ThingDef)
                        {
                            continue;
                        }

                        thingDef = (ThingDef) thing2.def.entityDefToBuild;
                    }

                    if (thingDef.category == ThingCategory.Building)
                    {
                        return "ASP.notplacenearbuildings".Translate();
                    }
                }
            }

            foreach (var solarPanel in map.listerBuildings.AllBuildingsColonistOfDef(AgrivoltaicSolarPanelDefOf
                .AgrivoltaicSolarPanel))
            {
                if (!occupiedRect.Overlaps(CellRect.CenteredOn(solarPanel.Position, 5, 5)))
                {
                    continue;
                }

                return "ASP.notplacenearbuildings".Translate();
            }

            return true;
        }
    }
}