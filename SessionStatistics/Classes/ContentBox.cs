using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoeHUD.Hud.UI;
using SharpDX;

namespace SessionStatistics.Classes
{
    class ContentBox
    {
        //FunctionVariables
        public Graphics Graphics;
        //TextVariables
        public String TextToDraw;
        public Int32 TextSize;
        public Color TextColor;
        //BoxVariables
        public Size2 BoxSize;
        public Vector2 BoxPositon;
        public Color BoxColor;
        public ContentBox()
        {
            Graphics = SessionStatisticsCore.API.Graphics;
            TextSize = SessionStatisticsCore.SettingsInstance.TextSize;
            TextColor = Color.White;
        }
        public ContentBox(Color _TextColor)
        {
            Graphics = SessionStatisticsCore.API.Graphics;
            TextSize = SessionStatisticsCore.SettingsInstance.TextSize;
            TextColor = _TextColor;
        }
        public virtual void Update()
        {
            TextSize = SessionStatisticsCore.SettingsInstance.TextSize;
            BoxSize = Graphics.MeasureText(TextToDraw, TextSize);
        }
        public void Draw()
        {
            Graphics.DrawBox(new RectangleF(BoxPositon.X, BoxPositon.Y, BoxSize.Width, BoxSize.Height), BoxColor);
            Graphics.DrawText(TextToDraw, TextSize, BoxPositon, TextColor);
        }
    }
}
