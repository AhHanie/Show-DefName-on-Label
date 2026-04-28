using Verse;

namespace SK_Show_DefName_on_Label
{
    public class ModSettings : Verse.ModSettings
    {
        public static bool ModEnabled = true;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref ModEnabled, "modEnabled", true);
        }
    }
}
