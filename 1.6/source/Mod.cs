using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace SK_Show_DefName_on_Label
{
    public class Mod : Verse.Mod
    {
        public static Mod Instance;

        public static void ApplyDefNamesToLabels<T>() where T : Def
        {
            foreach (T allDef in DefDatabase<T>.AllDefs)
            {
                if (!allDef.label.NullOrEmpty() && !allDef.defName.NullOrEmpty())
                {
                    string suffix = " @ " + allDef.defName;
                    if (!allDef.label.EndsWith(suffix))
                    {
                        allDef.label = allDef.label + suffix;
                    }
                    allDef.ClearCachedData();
                }
            }
        }

        public static void RevertDefNamesFromLabels<T>() where T : Def
        {
            foreach (T allDef in DefDatabase<T>.AllDefs)
            {
                if (!allDef.label.NullOrEmpty() && !allDef.defName.NullOrEmpty())
                {
                    string suffix = " @ " + allDef.defName;
                    if (allDef.label.EndsWith(suffix))
                    {
                        allDef.label = allDef.label.Substring(0, allDef.label.Length - suffix.Length);
                    }
                    allDef.ClearCachedData();
                }
            }
        }

        public static void ApplyAllDefNamesToLabels()
        {
            ApplyDefNamesToLabels<AbilityDef>();
            ApplyDefNamesToLabels<BiomeDef>();
            ApplyDefNamesToLabels<NeedDef>();
            ApplyDefNamesToLabels<ThingDef>();
            ApplyDefNamesToLabels<ThingCategoryDef>();
            ApplyDefNamesToLabels<TerrainDef>();
            ApplyDefNamesToLabels<TraitDef>();
            ApplyDefNamesToLabels<RecipeDef>();
            ApplyDefNamesToLabels<ResearchTabDef>();
            ApplyDefNamesToLabels<ResearchProjectDef>();
            ApplyDefNamesToLabels<IncidentDef>();
            ApplyDefNamesToLabels<IssueDef>();
            ApplyDefNamesToLabels<GeneDef>();
            ApplyDefNamesToLabels<StatDef>();
            ApplyDefNamesToLabels<PreceptDef>();
            ApplyDefNamesToLabels<HediffDef>();
            ApplyDefNamesToLabels<WorldObjectDef>();
            ApplyDefNamesToLabels<WorkGiverDef>();

            // Handle ThoughtDef stages specially
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
                        string suffix = " @ " + allDef.defName;
                        if (!stage.label.EndsWith(suffix))
                        {
                            stage.label = stage.label + suffix;
                        }
                    }
                }
            }
        }

        public static void RevertAllDefNamesFromLabels()
        {
            RevertDefNamesFromLabels<AbilityDef>();
            RevertDefNamesFromLabels<BiomeDef>();
            RevertDefNamesFromLabels<NeedDef>();
            RevertDefNamesFromLabels<ThingDef>();
            RevertDefNamesFromLabels<ThingCategoryDef>();
            RevertDefNamesFromLabels<TerrainDef>();
            RevertDefNamesFromLabels<TraitDef>();
            RevertDefNamesFromLabels<RecipeDef>();
            RevertDefNamesFromLabels<ResearchTabDef>();
            RevertDefNamesFromLabels<ResearchProjectDef>();
            RevertDefNamesFromLabels<IncidentDef>();
            RevertDefNamesFromLabels<IssueDef>();
            RevertDefNamesFromLabels<GeneDef>();
            RevertDefNamesFromLabels<StatDef>();
            RevertDefNamesFromLabels<PreceptDef>();
            RevertDefNamesFromLabels<HediffDef>();
            RevertDefNamesFromLabels<WorldObjectDef>();
            RevertDefNamesFromLabels<WorkGiverDef>();

            // Handle ThoughtDef stages specially
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
                        string suffix = " @ " + allDef.defName;
                        if (stage.label.EndsWith(suffix))
                        {
                            stage.label = stage.label.Substring(0, stage.label.Length - suffix.Length);
                        }
                    }
                }
            }
        }

        public static void SetDefLabelsEnabled(bool enabled, bool writeSettings = false)
        {
            if (ModSettings.ModEnabled == enabled)
            {
                return;
            }

            if (enabled)
            {
                ApplyAllDefNamesToLabels();
            }
            else
            {
                RevertAllDefNamesFromLabels();
            }

            ModSettings.ModEnabled = enabled;
            GenLabel.ClearCache();
            InspectPaneUtility.Reset();

            if (writeSettings)
            {
                Instance?.GetSettings<ModSettings>().Write();
            }
        }

        public Mod(ModContentPack content)
            : base(content)
        {
            Instance = this;
            new Harmony("sk.showdefnameonlabel").PatchAll();
            LongEventHandler.QueueLongEvent(Init, "Sk.Show_DefName_on_Label.Init", doAsynchronously: true, null);
        }

        public void Init()
        {
            GetSettings<ModSettings>();
            if (ModSettings.ModEnabled)
            {
                ApplyAllDefNamesToLabels();
            }
        }

        public override string SettingsCategory()
        {
            return "Show DefName on Label";
        }

        public override void DoSettingsWindowContents(Rect rect)
        {
            ModSettingsWindow.Draw(rect);
            base.DoSettingsWindowContents(rect);
        }
    }
}
