using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoeHUD.Plugins;
using PoeHUD.Hud.UI;

using SharpDX;

namespace SessionStatistics.Classes
{
    class DrawTable
    {
        public Dictionary<String, String> Content;
        public Graphics GraphicsController;
        private Color Background;

        public DrawTable(Color backgroundColor)
        {
            Content = new Dictionary<string, string>();
            GraphicsController = BasePlugin.API.Graphics;
            Background = backgroundColor;
        }

        public void AddRow(String rowTitle, String rowValue = "")
        {
            Content[rowTitle] = rowValue;
        }

        public void UpdateRow(String rowTitle, String rowValue)
        {
            Content[rowTitle] = rowValue;
        }

        virtual public void Draw(Vector2 position)
        {

        }

    }
}
