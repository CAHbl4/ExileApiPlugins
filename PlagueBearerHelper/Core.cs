using ExileCore;
using System.Linq;
using System.Numerics;

namespace PlagueBearerHelper
{
    public class Core : BaseSettingsPlugin<Settings>
    {
        public override void Render()
        {
            var buffs = GameController.Player.Buffs;
            if (buffs.Any(b => b.Name == "corrosive_shroud_at_max_damage"))
            {
                Graphics.DrawText("Bearer is Charged!", new Vector2(Settings.X, Settings.Y), Settings.TextColor, Settings.FontSize, Settings.Font);
            }
        }
    }
}
