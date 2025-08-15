using RimWorld;
using Verse;

namespace SK_Show_DefName_on_Label
{
    public class Mod : Verse.Mod
    {
        public static void Traverse<T>() where T : Def
        {
            foreach (T allDef in DefDatabase<T>.AllDefs)
            {
                if (!allDef.label.NullOrEmpty() && !allDef.defName.NullOrEmpty())
                {
                    allDef.label = allDef.label + " @ " + allDef.defName;
                }
            }
        }
        public Mod(ModContentPack content)
            : base(content)
        {
            LongEventHandler.QueueLongEvent(Init, "Sk.Show_DefName_on_Label.Init", doAsynchronously: true, null);
        }

        public void Init()
        {
            Traverse<AbilityDef>();
            Traverse<BiomeDef>();
            Traverse<NeedDef>();
            Traverse<ThingDef>();
            Traverse<ThingCategoryDef>();
            Traverse<TerrainDef>();
            Traverse<TraitDef>();
            Traverse<RecipeDef>();
            Traverse<ResearchTabDef>();
            Traverse<ResearchProjectDef>();
            Traverse<IncidentDef>();
            Traverse<IssueDef>();
            Traverse<GeneDef>();
            Traverse<StatDef>();
            Traverse<PreceptDef>();
            Traverse<HediffDef>();
            Traverse<WorldObjectDef>();
            Traverse<WorkGiverDef>();
            foreach (ThoughtDef allDef in DefDatabase<ThoughtDef>.AllDefs)
            {
                if (allDef.stages.NullOrEmpty() || allDef.defName.NullOrEmpty())
                {
                    continue;
                }
                foreach (ThoughtStage stage in allDef.stages)
                {
                    if (stage != null && !stage.label.NullOrEmpty())
                    {
                        stage.label = stage.label + " @ " + allDef.defName;
                    }
                }
            }
        }
    }
}
