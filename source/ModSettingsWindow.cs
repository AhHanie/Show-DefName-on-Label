using LessUI;
using System.Runtime.CompilerServices;
using UnityEngine;
using Verse;

namespace SK_Show_DefName_on_Label
{
    public class ModSettingsWindow
    {
        public static StrongBox<Vector2> scrollPosition = new StrongBox<Vector2>(Vector2.zero);
        public static void Draw(Rect parent)
        {
            ScrollCanvas canvas = new ScrollCanvas(rect: parent, scrollPositionBox: scrollPosition);
            Grid grid = new Grid(2, 2, widthMode: SizeMode.Fill, heightMode: SizeMode.Content, padding: 5f);
            Text.Font = GameFont.Small;

            Label modEnabledLabel = new Label(text: "ShowDefName.Settings.ModEnabled.Label".Translate(), alignment: Align.MiddleLeft);
            Label modEnabledInfoLabel = new Label(text: "ShowDefName.Settings.ModEnabled.Info.Label".Translate(), alignment: Align.MiddleLeft);

            Checkbox modEnabledCheckbox = new Checkbox(isChecked: ModSettings.modEnabled, alignment: Align.MiddleLeft);

            grid.AddChild(modEnabledInfoLabel)
                .AddChild(new Empty())
                .AddChild(modEnabledLabel)
                .AddChild(modEnabledCheckbox);

            canvas.AddChild(grid);

            canvas.Render();
        }
    }
}
