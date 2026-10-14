using HarmonyLib;
using RimWorld;
using Verse;

namespace SK_Show_DefName_on_Label
{
    [HarmonyPatch(typeof(PlaySettings), "DoMapControls")]
    [HarmonyPriority(Priority.Last)]
    public static class PlaySettings_DoMapControls_Patch
    {
        public static void Postfix(WidgetRow row)
        {
            PlaySettingsToggleDrawer.DrawDefLabelsToggle(row);
        }
    }

    [HarmonyPatch(typeof(PlaySettings), "DoWorldViewControls")]
    [HarmonyPriority(Priority.Last)]
    public static class PlaySettings_DoWorldViewControls_Patch
    {
        public static void Postfix(WidgetRow row)
        {
            PlaySettingsToggleDrawer.DrawDefLabelsToggle(row);
        }
    }

    public static class PlaySettingsToggleDrawer
    {
        public static void DrawDefLabelsToggle(WidgetRow row)
        {
            bool enabled = ModSettings.ModEnabled;
            string tooltip = "ShowDefName.PlaySettings.ToggleDefLabels".Translate();
            row.ToggleableIcon(ref enabled, TexButton.Info, tooltip, SoundDefOf.Mouseover_ButtonToggle);

            if (enabled != ModSettings.ModEnabled)
            {
                Mod.SetDefLabelsEnabled(enabled, writeSettings: true);
            }
        }
    }
}
