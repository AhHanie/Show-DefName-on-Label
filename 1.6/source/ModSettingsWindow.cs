using RimWorld;
using UnityEngine;
using Verse;

namespace SK_Show_DefName_on_Label
{
    public class ModSettingsWindow
    {
        public static void Draw(Rect parent)
        {
            Text.Font = GameFont.Small;

            Listing_Standard listing = new Listing_Standard();
            listing.Begin(parent);

            bool modEnabled = ModSettings.ModEnabled;
            listing.CheckboxLabeled(
                "ShowDefName.Settings.ModEnabled.Label".Translate(),
                ref modEnabled,
                "ShowDefName.Settings.ModEnabled.Label.Tooltip".Translate());

            if (modEnabled != ModSettings.ModEnabled)
            {
                Mod.SetDefLabelsEnabled(modEnabled);
            }

            listing.End();
        }
    }
}
