using System.Runtime.CompilerServices;
using Verse;

namespace SK_Show_DefName_on_Label
{
    public class ModSettings : Verse.ModSettings
    {
        public static StrongBox<bool> modEnabled = new StrongBox<bool>(true);

        public static bool ModEnabled { get => modEnabled.Value; }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref modEnabled.Value, "modEnabled", true);
        }
    }
}
