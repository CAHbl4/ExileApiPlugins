using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;
using SharpDX;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PlagueBearerHelper
{
    public class Settings : ISettings
    {
        public ToggleNode Enable { get; set; } = new ToggleNode(true);
        [Menu("X")]
        public RangeNode<int> X { get; set; } = new RangeNode<int>(0, 0, 3000);
        [Menu("Y")]
        public RangeNode<int> Y { get; set; } = new RangeNode<int>(0, 0, 3000);
        [Menu("Text Color")]
        public ColorNode TextColor { get; set; } = new ColorNode(Color.Azure);
        [Menu("Font size", "Currently not works. Because this option broke calculate how much pixels needs for render.")]
        [IgnoreMenu]
        public RangeNode<int> FontSize { get; set; } = new RangeNode<int>(13, 7, 36);
        [Menu("Font")]
        public ListNode Font { get; set; } = new ListNode { Values = GetFontNames() };

        private static List<string> GetFontNames()
        {
            var folder = "fonts";
            var files = Directory.GetFiles(folder);

            var fonts = new List<string>() { "Default:13" };

            if (!(Directory.Exists(folder) && files.Length > 0))
                return fonts;

            if (files.Contains($"{folder}\\config.ini"))
            {
                var lines = File.ReadAllLines($"{folder}\\config.ini");
                fonts.AddRange(lines);
            }
            return fonts;
        }
    }
}
